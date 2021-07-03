using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.Data;
using ZkConstruction.Models;
using ZkConstruction.ViewModel;

namespace ZkConstruction.Controllers
{
    public class ContractorController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ContractorController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Contractor.OrderByDescending(c => c.id).ToList());
        }
        public IActionResult Create(Contractor Contractor)
        {
            var viewmodel = new Contractor_VM
            {
                Cities = _context.City.OrderBy(c => c.Name).ToList(),
                Contractor = Contractor,
            };
            return View(viewmodel);
        }
        [HttpPost]
        public IActionResult save(Contractor Contractor)
        {
            string direction = "";
            if (Contractor.id == 0)
            {
                var count = _context.ThirdLevel.Where(c => c.AccountTitle == Contractor.Name && c.Headid == 2 && c.SecondHeadid == 2000002).Count();
                if (count != 0)
                {
                    var viewmodel = new Contractor_VM
                    {
                        Cities = _context.City.OrderBy(c => c.Name).ToList(),
                        Contractor = Contractor,
                    };
                    TempData["Duplicate"] = " Employee With Name " + Contractor.Name + " Already Exists ";
                    return View("Create", viewmodel);
                }
                else
                {
                    if (_context.ThirdLevel.Where(c => c.Headid == 2).Count() == 0)
                    {
                        Contractor.AccountNo = 2100001;
                    }
                    else
                    {
                        Contractor.AccountNo = _context.ThirdLevel.Where(c => c.Headid == 2).Max(x => x.AccountNo) + 1;
                    }
                    _context.Add(Contractor);
                    _context.Database.ExecuteSqlRaw("INSERT INTO ThirdLevel (AccountNo, Headid, SubHeadid, SecondHeadid, AccountTitle, AccountType, Dr, Cr, Comid) " +
                        "VALUES ('" + Contractor.AccountNo + "','2','2001','2000002','" + Contractor.Name + "','Contractor',0,0,1)");
                    TempData["Insert"] = "Submitted Successfully";
                    direction = "Create";
                }
            }
            else
            {
                var db = _context.Contractor.SingleOrDefault(c => c.id == Contractor.id);
                db.Name = Contractor.Name;
                db.Email = Contractor.Email;
                db.Mobile = Contractor.Mobile;
                db.City = Contractor.City;
                db.Country = Contractor.Country;
                db.Address = Contractor.Address;
                _context.Database.ExecuteSqlRaw("Update ThirdLevel Set AccountTitle= '" + Contractor.Name + "' WHERE AccountNo=" + Contractor.AccountNo + " ");
                TempData["update"] = "Updated Successfully";
                direction = "Index";
            }
            _context.SaveChanges();

            return RedirectToAction(direction);
        }
    }
}
