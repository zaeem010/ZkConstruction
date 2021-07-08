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
    public class ResultController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ResultController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var ManagerList = _context.DEmployee.FromSqlRaw("SELECT * FROM DEmployee WHERE (Designation = 1)").ToList();
            var EmployeeList = _context.DEmployee.FromSqlRaw("SELECT * FROM DEmployee WHERE (Designation NOT IN (1))").ToList();
            var VM = new ResultVM
            {
                ManagerList = ManagerList,
                EmployeeList=EmployeeList,
            };
            return View(VM);
        }
        
        [HttpPost]
        public IActionResult Search(int Mangerid, string Stdate, string Endate,int Emp,int Empid)
        {
            string EmpName = "";
            int Manid = new Repo<string>().GetMaxId("SELECT id FROM DEmployee WHERE (AccountNo = " + Mangerid + ")");
            var Res = new Repo<ResultVMQ>().GetAllData("SELECT Site.Name AS SiteName, EmployeeAssigned.StartDateTime, EmployeeAssigned.CloseDateTime, EmployeeAssigned.Siteid FROM EmployeeAssigned INNER JOIN Site ON EmployeeAssigned.Siteid = Site.id WHERE(LEFT(EmployeeAssigned.CloseDateTime, 10) BETWEEN '"+ Stdate +"' AND '"+ Endate +"' OR LEFT(EmployeeAssigned.StartDateTime, 10) BETWEEN '"+ Stdate +"' AND '"+ Endate +"') AND (EmployeeAssigned.Employeeid = "+ Empid +")").ToList();
            var ResManagerFirst = new Repo<ResultManagerFirstVMQ>().GetAllData("SELECT Home.site, Site.Name AS SiteName FROM Home INNER JOIN Site ON Home.site = Site.id WHERE(Home.Manager = "+ Manid + ") GROUP BY Home.site, Site.Name").ToList();
            var ResManagerSecond = new Repo<ResultManagerSecondVMQ>().GetAllData("SELECT Home.site, EmployeeAssigned.StartDateTime, EmployeeAssigned.CloseDateTime, DEmployee.Name AS EmpName FROM Home INNER JOIN EmployeeAssigned ON Home.Proid = EmployeeAssigned.Proid INNER JOIN DEmployee ON EmployeeAssigned.Employeeid = DEmployee.AccountNo WHERE(Home.Manager = "+ Manid +")").ToList();
           
            if (Mangerid != 0)
            {
                EmpName = new Repo<string>().Getstring("SELECT Name FROM DEmployee WHERE (AccountNo = " + Mangerid + ")");
            }
            if (Empid != 0)
            {
                EmpName = new Repo<string>().Getstring("SELECT Name FROM DEmployee WHERE (AccountNo = " + Empid + ")");
            }
            var VM = new ResultVM
            {
                Stdate = Stdate,
                Endate = Endate,
                ResultVMQList=Res,
                Eid=Empid,
                E=Emp,
                EmpName=EmpName,
                ResultManagerFirstVMQList = ResManagerFirst,
                ResultManagerSecondVMQList=ResManagerSecond,
            };
            return View(VM);
        }
        [HttpPost]
        public IActionResult Create(int Emp, string Stdate, string Endate)
        {
            List<DEmployee> EmployeeList = new List<DEmployee>();
            if (Emp == 1)
            {
                EmployeeList = _context.DEmployee.FromSqlRaw("SELECT * FROM DEmployee WHERE (Designation = 1)").ToList();
            }
            else
            {
                EmployeeList = _context.DEmployee.FromSqlRaw("SELECT * FROM DEmployee WHERE (Designation NOT IN (1))").ToList();
            }
            var VM = new ResultVM
            {
                EmployeeList = EmployeeList,
                Stdate = Stdate,
                Endate = Endate,
                E = Emp,
            };
            return View(VM);
        }
    }
}
