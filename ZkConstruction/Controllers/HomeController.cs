using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.Data;
using ZkConstruction.Data.Repository;
using ZkConstruction.Models;
using ZkConstruction.ViewModel;
using ZkConstruction.ViewModelQuery;

namespace ZkConstruction.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Indexx()
        {
            //SqlParameter[] Parrameters = new SqlParameter[]
            //{
            //     new SqlParameter("@id",id)
            //};
            var List = new Repo<ManageVMQ>().GetAllData("SpMainIndex");
            var VM = new HomeEditVM
            {
                ManageVMQList = List.OrderBy(c => c.Proid).ToList(),
                CompanyList = _context.Company.ToList(),
                SiteList = _context.Site.ToList(),
                CustomerList = _context.Customer.ToList(),
                EmployeeList = _context.DEmployee.ToList(),
                EmployeeAssignedPaintList = _context.EmployeeAssigned.FromSqlRaw("SELECT * FROM EmployeeAssigned WHERE(Type = 'Painting')").ToList(),
                EmployeeAssignedFloorList = _context.EmployeeAssigned.FromSqlRaw("SELECT * FROM EmployeeAssigned WHERE(Type = 'Flooring')").ToList(),
                EmployeeAssignedFloorListChecked = new Repo<EmpFloorCheckedVMQ>().GetAllData("SELECT EmployeeAssigned.id, EmployeeAssigned.Proid, EmployeeAssigned.Employeeid, EmployeeAssigned.Type, DEmployee.Name AS EmpName, EmployeeAssigned.CloseDateTime FROM EmployeeAssigned INNER JOIN DEmployee ON EmployeeAssigned.Employeeid = DEmployee.AccountNo WHERE(EmployeeAssigned.Type = 'Flooring')").ToList(),
                EmployeeAssignedPaintListChecked = new Repo<EmpFloorCheckedVMQ>().GetAllData("SELECT EmployeeAssigned.id, EmployeeAssigned.Proid, EmployeeAssigned.Employeeid, EmployeeAssigned.Type, DEmployee.Name AS EmpName, EmployeeAssigned.CloseDateTime FROM EmployeeAssigned INNER JOIN DEmployee ON EmployeeAssigned.Employeeid = DEmployee.AccountNo WHERE(EmployeeAssigned.Type = 'Painting')").ToList(),
                ManagerList=_context.DEmployee.FromSqlRaw("SELECT * FROM DEmployee WHERE (Designation = 1)").ToList(),
            };
            return View(VM);
        }
        public IActionResult Index()
        {
            var projects = new Repo<ProjectVMQS>().GetAllData("SELECT EProject.Name, EProject.StDate, EProject.HandDate, EProject.Proid, Site.Name AS Site, EProject.Status, EProject.site AS Siteid FROM EProject INNER JOIN Site ON EProject.site = Site.id").ToList();
            var viewmodel = new Dashboard_VM
            {
                ProjectsVMQList=projects,
            };
            int id = 40;
            HttpContext.Session.SetString("MyAwesomeSessionValue", id.ToString());
            if (HttpContext.Session.GetString("UserId") != "")
            {
                return View(viewmodel);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public IActionResult Projects(string status)
        {
            if (status == "All")
            {
                var projects = new Repo<ProjectVMQS>().GetAllData("SELECT EProject.Name, EProject.StDate, EProject.HandDate, EProject.Proid, Site.Name AS Site, EProject.Status, EProject.site AS Siteid FROM EProject INNER JOIN Site ON EProject.site = Site.id").ToList();
                var viewmodel = new Dashboard_VM
                {
                    ProjectsVMQList = projects,
                };
                return View("Index", viewmodel);
            }
            else
            {
                var project = new Repo<ProjectVMQS>().GetAllData("SELECT EProject.Name, EProject.StDate, EProject.HandDate, EProject.Proid, Site.Name AS Site, EProject.Status, EProject.site AS Siteid FROM EProject INNER JOIN Site ON EProject.site = Site.id WHERE (EProject.Status = '" + status + "')").ToList();
                var viewmodel = new Dashboard_VM
                {
                    ProjectsVMQList = project,
                };
                return View("Index", viewmodel);
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserLogin UserLogin)
        {
            string dir = "";
            if (ModelState.IsValid)
            {
                var obj = _context.UserLogin.FromSqlRaw("SELECT * FROM UserLogin WHERE Name='" + UserLogin.Name + "' AND Password ='" + UserLogin.Password + "' ").FirstOrDefault();
                
                if (obj != null)
                {
                    HttpContext.Session.SetString("UserId", obj.id.ToString());
                    HttpContext.Session.SetString("UserName", obj.Name.ToString()) ;
                    dir = "Indexx";
                }
                else
                {
                    TempData["Invalid"] = "Invalid Login Details";
                    dir = "Login";
                }
            }
            return RedirectToAction(dir);
        }
        public ActionResult LogOut()
        {
            string id = "";
            HttpContext.Session.SetString("UserId", id);
            return RedirectToAction("Login");
        }
    }
}
