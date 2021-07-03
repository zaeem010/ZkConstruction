using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.Data;
using ZkConstruction.Data.Repository;
using ZkConstruction.Models;
using ZkConstruction.ViewModel;

namespace ZkConstruction.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment host;
        public EmployeeController(ApplicationDbContext context, IWebHostEnvironment host)
        {
            _context = context;
            this.host = host;
        }
        public IActionResult Index()
        {
            return View(new Repo<DEmployee>().GetAllData("SELECT DEmployee.id, DEmployee.AccountNo, DEmployee.Name, DEmployee.Email, DEmployee.Mobile, DEmployee.City, DEmployee.Country, DEmployee.Address, DEmployee.DOB, DEmployee.DOJ, DEmployee.PerHourSalary, DEmployee.Image, Designation.Name AS Designation FROM DEmployee INNER JOIN Designation ON DEmployee.Designation = Designation.id").OrderByDescending(c => c.AccountNo).ToList());
        }
        public IActionResult Create(DEmployee DEmployee)
        {
            var viewmodel = new Employee_VM
            {
                Cities = _context.City.OrderBy(c => c.Name).ToList(),
                Designationlist = _context.Designation.OrderBy(c => c.Name).ToList(),
                DEmployee = DEmployee,
            };
            return View(viewmodel);
        }
        [HttpPost]
        public IActionResult save(DEmployee DEmployee)
        {
            string direction = "";
            Random r = new Random();
            int num = r.Next();
            var webrootpath = host.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            if (files.Count > 0)
            {
                var uploads = Path.Combine(webrootpath, "Uploads");
                var filename = Path.GetFileName(files[0].FileName);
                using (var stream = new FileStream(Path.Combine(uploads, num + DEmployee.Designation + filename), FileMode.Create))
                {
                    files[0].CopyTo(stream);
                }
                DEmployee.Image = num + DEmployee.Designation + filename;
            }
            if (DEmployee.id == 0)
            {
                var count = _context.ThirdLevel.Where(c => c.AccountTitle == DEmployee.Name && c.Headid == 2 && c.SecondHeadid == 2000001).Count();
                if (count != 0)
                {
                    var viewmodel = new Employee_VM
                    {
                        Cities = _context.City.OrderBy(c => c.Name).ToList(),
                        DEmployee = DEmployee,
                    };
                    TempData["Duplicate"] = " Employee With Name " + DEmployee.Name + " Already Exists ";
                    return View("Create", viewmodel);
                }
                else
                {
                    if (_context.ThirdLevel.Where(c => c.Headid == 2).Count() == 0)
                    {
                        DEmployee.AccountNo = 2100001;
                    }
                    else
                    {
                        DEmployee.AccountNo = _context.ThirdLevel.Where(c => c.Headid == 2).Max(x => x.AccountNo) + 1;
                    }
                    //DEmployee.Image = num + DEmployee.id + filename;
                  
                    _context.Add(DEmployee);
                    _context.Database.ExecuteSqlRaw("INSERT INTO ThirdLevel (AccountNo, Headid, SubHeadid, SecondHeadid, AccountTitle, AccountType, Dr, Cr, Comid) " +
                        "VALUES ('" + DEmployee.AccountNo + "','2','2001','2000001','" + DEmployee.Name + "','Employee',0,0,1)");
                    TempData["Insert"] = "Submitted Successfully";
                    direction = "Create";
                }
            }
            else
            {
                var db = _context.DEmployee.SingleOrDefault(c => c.AccountNo == DEmployee.AccountNo);
                db.Name = DEmployee.Name;
                db.DOB = DEmployee.DOB;
                db.Email = DEmployee.Email;
                db.Mobile = DEmployee.Mobile;
                db.Designation = DEmployee.Designation;
                db.DOJ = DEmployee.DOJ;
                db.PerHourSalary = DEmployee.PerHourSalary;
                db.City = DEmployee.City;
                db.Country = DEmployee.Country;
                db.Address = DEmployee.Address;
                db.StTime = DEmployee.StTime;
                db.EnTime = DEmployee.EnTime;
                db.Image = DEmployee.Image;
                _context.Database.ExecuteSqlRaw("Update ThirdLevel Set AccountTitle= '" + DEmployee.Name + "' WHERE AccountNo=" + DEmployee.AccountNo + " ");
                TempData["update"] = "Updated Successfully";
                direction = "Index";
            }
            _context.SaveChanges();

            return RedirectToAction(direction);
        }
        public ActionResult Edit(int? id)
        {
            var listed = _context.DEmployee.SingleOrDefault(c => c.AccountNo == id);
            var viewmodel = new Employee_VM
            {
                DEmployee = listed,
                Designationlist = _context.Designation.OrderBy(c => c.Name).ToList(),
                Cities = _context.City.OrderByDescending(c => c.Name).ToList(),
            };
            return View("Create", viewmodel);
        }
        public IActionResult Delete(int Acc)
        {
            var lst = _context.DEmployee.SingleOrDefault(c => c.AccountNo == Acc);
            var lstt = _context.ThirdLevel.SingleOrDefault(c => c.AccountNo == Acc);
            _context.Remove(lst);
            _context.Remove(lstt);
            _context.SaveChanges();
            TempData["Delete"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
