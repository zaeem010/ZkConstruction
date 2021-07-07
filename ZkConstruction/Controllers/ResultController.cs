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
            };
            return View(VM);
        }
    }
}
