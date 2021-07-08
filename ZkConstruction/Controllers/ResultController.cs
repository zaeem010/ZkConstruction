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
            return View();
        }
        [HttpPost]
        public IActionResult Create(int Emp ,string Stdate,string Endate)
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
                Stdate=Stdate,
                Endate=Endate,
                E=Emp,
            };
            return View(VM);
        }
        [HttpPost]
        public IActionResult Search(int Empid, string Stdate, string Endate,int Emp)
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
            var Res = new Repo<ResultVMQ>().GetAllData("SELECT Site.Name AS SiteName, EmployeeAssigned.StartDateTime, EmployeeAssigned.CloseDateTime, EmployeeAssigned.Siteid FROM EmployeeAssigned INNER JOIN Site ON EmployeeAssigned.Siteid = Site.id WHERE(LEFT(EmployeeAssigned.CloseDateTime, 10) BETWEEN '"+ Stdate +"' AND '"+ Endate +"' OR LEFT(EmployeeAssigned.StartDateTime, 10) BETWEEN '"+ Stdate +"' AND '"+ Endate +"') AND (EmployeeAssigned.Employeeid = "+ Empid +")").ToList();
            var VM = new ResultVM
            {
                EmployeeList = EmployeeList,
                Stdate = Stdate,
                Endate = Endate,
                E = Emp,
                ResultVMQList=Res,
                Eid=Empid,
            };
            return View(VM);
        }
    }
}
