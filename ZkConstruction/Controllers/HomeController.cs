using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            var List = new Repo<ManageVMQ>().GetAllData("SELECT derivedtbl_3.PaEmNames, derivedtbl_3.FlEmNames, derivedtbl_3.PaEm, derivedtbl_3.FlEm, derivedtbl_3.Fl, derivedtbl_3.Pa, derivedtbl_3.Wa, derivedtbl_3.Cl, derivedtbl_3.Name, derivedtbl_3.StDate, derivedtbl_3.HandDate, derivedtbl_3.Floor, derivedtbl_3.FlooringRoom, derivedtbl_3.Electricity, derivedtbl_3.Proid, derivedtbl_3.Sr, derivedtbl_3.WorkHours, derivedtbl_3.FlooringHours, derivedtbl_3.PaintingHours, derivedtbl_3.RemainingHours, derivedtbl_3.StTime, derivedtbl_3.SiteName, derivedtbl_3.CompanyName, derivedtbl_3.CustomerName, derivedtbl_3.Manager, DEmployee_3.Name AS ManagerName FROM(SELECT (SELECT ISNULL(CASE WHEN Emp1 = Emp2 THEN Emp1 ELSE Emp1 + ',' + Emp2 END, '') AS Employees FROM (SELECT (SELECT TOP (1) (SELECT Name FROM DEmployee WHERE (AccountNo = EmployeeAssigned_1.Employeeid)) AS Empname FROM EmployeeAssigned AS EmployeeAssigned_1 WHERE (Proid = derivedtbl_1.Proid) AND (Type = 'Painting') ORDER BY Employeeid) AS Emp1, (SELECT TOP (1) (SELECT Name FROM DEmployee AS DEmployee_1 WHERE (AccountNo = EmployeeAssigned_1.Employeeid)) AS Empname FROM EmployeeAssigned AS EmployeeAssigned_1 WHERE (Proid = derivedtbl_1.Proid) AND (Type = 'Painting') ORDER BY Employeeid DESC) AS Emp2 FROM (SELECT Proid, COUNT(*) AS cntr FROM EmployeeAssigned AS EmployeeAssigned_1 WHERE (Proid = Home.Proid) AND (Type = 'Painting') GROUP BY Proid) AS derivedtbl_1) AS derivedtbl_2) AS PaEmNames, (SELECT ISNULL(CASE WHEN Emp1 = Emp2 THEN Emp1 ELSE Emp1 + ',' + Emp2 END, '') AS Employees FROM (SELECT (SELECT TOP (1) (SELECT Name FROM DEmployee AS DEmployee_2 WHERE (AccountNo = EmployeeAssigned_1.Employeeid)) AS Empname FROM EmployeeAssigned AS EmployeeAssigned_1 WHERE (Proid = derivedtbl_1_1.Proid) AND (Type = 'Flooring') ORDER BY Employeeid) AS Emp1, (SELECT TOP (1) (SELECT Name FROM DEmployee AS DEmployee_1 WHERE (AccountNo = EmployeeAssigned_1.Employeeid)) AS Empname FROM EmployeeAssigned AS EmployeeAssigned_1 WHERE (Proid = derivedtbl_1_1.Proid) AND (Type = 'Flooring') ORDER BY Employeeid DESC) AS Emp2 FROM (SELECT Proid, COUNT(*) AS cntr FROM EmployeeAssigned AS EmployeeAssigned_1 WHERE (Proid = Home.Proid) AND (Type = 'Flooring') GROUP BY Proid) AS derivedtbl_1_1) AS derivedtbl_2_1) AS FlEmNames, (SELECT COUNT(*) AS PaEm FROM EmployeeAssigned WHERE (Proid = Home.Proid) AND (Type = 'Painting')) AS PaEm, (SELECT COUNT(*) AS Expr1 FROM EmployeeAssigned AS EmployeeAssigned_1 WHERE (Proid = Home.Proid) AND (Type = 'Flooring')) AS FlEm, (SELECT TOP (1) CASE WHEN Name = 'Flooring' THEN 'Yes' ELSE 'No' END AS Expr1 FROM EPchild WHERE (Proid = Home.Proid) AND (Name = 'Flooring')) AS Fl, (SELECT TOP (1) CASE WHEN Name = 'Painting' THEN 'Yes' ELSE 'No' END AS Expr1 FROM EPchild AS EPchild_3 WHERE (Proid = Home.Proid) AND (Name = 'Painting')) AS Pa, (SELECT TOP (1) CASE WHEN Name = 'Wallpaper' THEN 'Yes' ELSE 'No' END AS Expr1 FROM EPchild AS EPchild_2 WHERE (Proid = Home.Proid) AND (Name = 'Wallpaper')) AS Wa, (SELECT TOP (1) CASE WHEN Name = 'Cleaning' THEN 'Yes' ELSE 'No' END AS Expr1 FROM EPchild AS EPchild_1 WHERE (Proid = Home.Proid) AND (Name = 'Cleaning')) AS Cl, Home.Name, Home.StDate, Home.HandDate, Home.Floor, Home.FlooringRoom, Home.Electricity, Home.Proid, Home.Sr, Home.WorkHours, Home.FlooringHours, Home.Manager, Home.PaintingHours, Home.RemainingHours, Home.StTime, Site.Name AS SiteName, LEFT(Company.Name, 1) AS CompanyName, LEFT(Customer.Name, 2) AS CustomerName FROM Home INNER JOIN Site ON Home.site = Site.id INNER JOIN Company ON Home.Comid = Company.id INNER JOIN Customer ON Home.Customerid = Customer.id) AS derivedtbl_3 INNER JOIN DEmployee AS DEmployee_3 ON derivedtbl_3.Manager = DEmployee_3.id");
            var VM = new HomeEditVM
            {
                ManageVMQList = List.OrderBy(c => c.Proid).ToList(),
                CompanyList = _context.Company.ToList(),
                SiteList = _context.Site.ToList(),
                CustomerList = _context.Customer.ToList(),
                EmployeeList = _context.DEmployee.ToList(),
                EmployeeAssignedPaintList = _context.EmployeeAssigned.FromSqlRaw("SELECT * FROM EmployeeAssigned WHERE(Type = 'Painting')").ToList(),
                EmployeeAssignedFloorList = _context.EmployeeAssigned.FromSqlRaw("SELECT * FROM EmployeeAssigned WHERE(Type = 'Flooring')").ToList(),
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
