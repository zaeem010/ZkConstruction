using Microsoft.AspNetCore.Mvc;
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
    public class AbsentUserController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AbsentUserController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var List = new Repo<AbsentVMQ>().GetAllData("SELECT AbsentUser.id, AbsentUser.Start, AbsentUser.[End], DEmployee.Name AS EmployeeName, EProject.Name AS ProjectName FROM AbsentUser INNER JOIN DEmployee ON AbsentUser.Employeeid = DEmployee.AccountNo INNER JOIN EProject ON AbsentUser.Proid = EProject.Proid").ToList();
            return View(List);
        }
        public IActionResult Create(AbsentUser AbsentUser)
        {
            var VM = new AbsentUserVM
            {
                ProjectList = _context.EProject.ToList(),
                EmployeeList = _context.DEmployee.ToList(),
                AbsentUser =AbsentUser
            };
            return View(VM);
        }
        [HttpPost]
        public IActionResult Save(AbsentUser AbsentUser)
        {
            string d = "";
            if (AbsentUser.id==0)
            {
                _context.AbsentUser.Add(AbsentUser);
                d = "Create";
                TempData["Insert"] = "Inserted Successfully";
            }
            else
            {
                var db = _context.AbsentUser.SingleOrDefault(c=>c.id == AbsentUser.id);
                db.Proid = AbsentUser.Proid;
                db.Employeeid = AbsentUser.Employeeid;
                db.Start = AbsentUser.Start;
                db.End = AbsentUser.End;
                d = "Index";
                TempData["update"] = "Updated Successfully";
            }
            _context.SaveChanges();
            return RedirectToAction(d);
        }
        public IActionResult Edit(int id)
        {
            var db = _context.AbsentUser.SingleOrDefault(c => c.id == id);
            var VM = new AbsentUserVM
            {
                ProjectList = _context.EProject.ToList(),
                EmployeeList = _context.DEmployee.ToList(),
                AbsentUser = db
            };
            return View("Create",VM);
        }
    }
}
