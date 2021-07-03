using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.Data;
using ZkConstruction.Models;

namespace ZkConstruction.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CompanyController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Company.ToList());
        }
        public IActionResult Create(Company Company)
        {
            return View(Company);
        }
        [HttpPost]
        public IActionResult Save(Company Company)
        {
            string dr = "";
            if (Company.id == 0)
            {
                _context.Company.Add(Company);
                dr = "Create";
                TempData["Insert"] = "Registered Successfully";
            }
            else
            {
                var db = _context.Company.SingleOrDefault(c=>c.id == Company.id);
                db.Name = Company.Name;
                dr = "Index";
                TempData["Update"] = "Updated Successfully";
            }
            _context.SaveChanges();
            return RedirectToAction(dr);
        }
        public IActionResult Edit(int id)
        {
            var db = _context.Company.SingleOrDefault(c => c.id == id);
            return View("Create",db);
        }
    }
}
