using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.Data;
using ZkConstruction.Data.Repository;
using ZkConstruction.Models;
using ZkConstruction.ViewModel;
using ZkConstruction.ViewModelQuery;

namespace ZkConstruction.Controllers
{
    public class DailySheduleController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DailySheduleController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(new Repo<DailysheduleVMQ>().GetAllData("SELECT DailyShedule.id, DailyShedule.Date, DailyShedule.Sheduleid, EProject.Name AS ProjectName, Site.Name AS SiteName FROM DailyShedule INNER JOIN EProject ON DailyShedule.Projectid = EProject.Proid INNER JOIN Site ON DailyShedule.Siteid = Site.id"));
        }
        public IActionResult Create(DailyShedule DailyShedule)
        {
            if (_context.DailyShedule.Count() == 0)
            {
                DailyShedule.Sheduleid = 1;
            }
            else
            {
                DailyShedule.Sheduleid = _context.DailyShedule.Max(x => x.Sheduleid) + 1;
            }
            var viewmodel = new DailyShedule_VM
            {
                ProjectList = _context.EProject.ToList(),
                EmployeeList = new Repo<DEmployee>().GetAllData("SELECT DEmployee.id, DEmployee.AccountNo, DEmployee.Name, DEmployee.Email, DEmployee.Mobile, DEmployee.City, DEmployee.Country, DEmployee.Address, DEmployee.DOB, DEmployee.DOJ, DEmployee.PerHourSalary, Designation.Name AS Designation FROM DEmployee INNER JOIN Designation ON DEmployee.Designation = Designation.id").ToList(),
                SectionList = _context.Section.ToList(),
                SiteList = _context.Site.ToList(),
                DailyShedule = DailyShedule
            };
            return View(viewmodel);
        }
        [HttpGet]
        public JsonResult ProductList(int id)
        {
            return Json(_context.EPchild.Where(c => c.Proid == id).ToList());
        }
        [HttpGet]
        public JsonResult SubSection(int id)
        {
            return Json(_context.SubSection.Where(c => c.Sectionid == id).ToList());
        }
        [HttpGet]
        public JsonResult EployeeName(int id)
        {
            return Json(_context.DEmployee.SingleOrDefault(c=> c.AccountNo== id));
        }
        [HttpGet]
        public JsonResult TaskName(int id)
        {
            return Json(_context.Section.SingleOrDefault(c=> c.id== id));
        }
        [HttpGet]
        public JsonResult SubTaskName(int id)
        {
            return Json(_context.SubSection.SingleOrDefault(c=> c.id== id));
        }
        public IActionResult save(DailyShedule DailyShedule ,string[] Employee,string[] Section,string[] Subsec)
        {
            string direction = "";
            if (DailyShedule.id == 0)
            {
                for (int i = 0; i < Employee.Count(); i++)
                {
                    _context.Database.ExecuteSqlRaw("INSERT INTO DailySheduleChild(Sheduleid, Sectionid, Subsectionid, Employeeid,Status) VALUES " +
                    "('"+ DailyShedule.Sheduleid + "','" + Section[i] + "','"+ Subsec[i] +"','"+ Employee[i] +"','Pending')");
                }
                _context.Add(DailyShedule);
                TempData["Insert"] = "Submitted Successfully";
                direction = "Create";
            }
            else
            {
                var db = _context.DailyShedule.SingleOrDefault(c => c.id == DailyShedule.id);
                db.Projectid = DailyShedule.Projectid;
                db.Date = DailyShedule.Date;
                db.Siteid = DailyShedule.Siteid;
                _context.Database.ExecuteSqlRaw("DELETE FROM DailySheduleChild WHERE (Sheduleid = " + DailyShedule.Sheduleid +")");
                for (int i = 0; i < Employee.Count(); i++)
                {
                    _context.Database.ExecuteSqlRaw("INSERT INTO DailySheduleChild(Sheduleid, Sectionid, Subsectionid, Employeeid,Status) VALUES " +
                    "('" + DailyShedule.Sheduleid + "','" + Section[i] + "','" + Subsec[i] + "','" + Employee[i] + "','Pending')");
                }
                TempData["update"] = "Updated Successfully";
                direction = "Index";
            }
            _context.SaveChanges();
            return RedirectToAction(direction);
        }
        public ActionResult Edit(int? id)
        {
            var Daily = _context.DailyShedule.SingleOrDefault(c => c.Sheduleid == id);
            var viewModel = new DailyShedule_VM
            {
                DailyShedule = Daily,
                ProjectList = _context.EProject.ToList(),
                EmployeeList = new Repo<DEmployee>().GetAllData("SELECT DEmployee.id, DEmployee.AccountNo, DEmployee.Name, DEmployee.Email, DEmployee.Mobile, DEmployee.City, DEmployee.Country, DEmployee.Address, DEmployee.DOB, DEmployee.DOJ, DEmployee.PerHourSalary, Designation.Name AS Designation FROM DEmployee INNER JOIN Designation ON DEmployee.Designation = Designation.id").ToList(),
                ProjectchildList = _context.EPchild.FromSqlRaw("SELECT * FROM EPchild WHERE (Proid = '" + Daily.Projectid + "')").ToList(),
                SiteList = _context.Site.ToList(),
                DailysheduleVMQList = new Repo<DailyChildVMQ>().GetAllData("SELECT DailySheduleChild.id, DailySheduleChild.Sheduleid, Section.Name AS SectionName, SubSection.Name AS SubsectionName, DEmployee.Name AS EmployeeName, DailySheduleChild.Sectionid, DailySheduleChild.Subsectionid, DailySheduleChild.Employeeid, Designation.Name AS Designation FROM DailySheduleChild INNER JOIN Section ON DailySheduleChild.Sectionid = Section.id INNER JOIN SubSection ON DailySheduleChild.Subsectionid = SubSection.id INNER JOIN DEmployee ON DailySheduleChild.Employeeid = DEmployee.AccountNo INNER JOIN Designation ON DEmployee.Designation = Designation.id WHERE(DailySheduleChild.Sheduleid = "+ id +")").ToList(),
            };
            return View("Create", viewModel);
        }
        public IActionResult Delete(int id)
        {
            var Daily = _context.DailyShedule.SingleOrDefault(c => c.Sheduleid == id);
            _context.Remove(Daily);
            _context.SaveChanges();
            TempData["Delete"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
