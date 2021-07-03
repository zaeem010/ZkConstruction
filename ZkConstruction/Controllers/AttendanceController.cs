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
    public class AttendanceController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AttendanceController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var List = new Repo<AttendanceVMQ>().GetAllData("SELECT EmployeeAttendance.EmpCode, EmployeeAttendance.Status, EmployeeAttendance.CheckInOut, DEmployee.Name FROM EmployeeAttendance INNER JOIN DEmployee ON DEmployee.AccountNo = EmployeeAttendance.EmpCode ORDER BY EmployeeAttendance.EmpCode, EmployeeAttendance.Status").ToList();
            return View(List);
        }
        public IActionResult Create(EmployeeAttendance EmployeeAttendance)
        {
            var EmployeeList = new Repo<DEmployee>().GetAllData("SELECT DEmployee.id, DEmployee.AccountNo, DEmployee.Name, DEmployee.Email, DEmployee.Mobile, DEmployee.City, DEmployee.Country, DEmployee.Address, DEmployee.DOB, DEmployee.DOJ, DEmployee.PerHourSalary, Designation.Name AS Designation FROM DEmployee INNER JOIN Designation ON DEmployee.Designation = Designation.id").ToList();
            var AttendanceVM = new AttendanceVM
            {
                EmployeeList= EmployeeList,
                EmployeeAttendance =EmployeeAttendance
            };
            return View(AttendanceVM);
        }
        public IActionResult Save(DateTime In , DateTime Out ,int[] Emp)
        {
            for (int i=0; i < Emp.Count(); i++)
            {
                if (In.Year.ToString() != "1")
                {
                    _context.Database.ExecuteSqlRaw("INSERT INTO EmployeeAttendance (EmpCode, Status, CheckInOut, Reamark) VALUES " +
                        "("+ Emp[i] +",'In','"+ In +"','')");
                }
                if (Out.Year.ToString() != "1")
                {
                    _context.Database.ExecuteSqlRaw("INSERT INTO EmployeeAttendance (EmpCode, Status, CheckInOut, Reamark) VALUES " +
                        "(" + Emp[i] + ",'Out','" + Out + "','')");
                }
            }
            TempData["Insert"] = "Query Excuted Successfully";
            return RedirectToAction("Create");
        }
    }
}
