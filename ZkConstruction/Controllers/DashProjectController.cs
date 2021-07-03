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
    public class DashProjectController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DashProjectController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Create(EProject EProject, EProjectchild EProjectchild)
        {
            if (_context.EProject.Count() == 0)
            {
                EProject.Proid = 1;
            }
            else
            {
                EProject.Proid = _context.EProject.Max(x => x.Proid) + 1;
            }
            EProject.Status = "Pending";
            var viewModel = new Project_VM
            {
                EProject = EProject,
                EProjectchild = EProjectchild,
                SiteList = _context.Site.ToList(),
                MangerList = _context.DEmployee.Where(c => c.Designation == "1").ToList(),
                SectionList = _context.Section.ToList(),
                CompanyList = _context.Company.ToList(),
                CustomerList = _context.Customer.ToList(),
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult save(EProject EProject, int[] child ,Home Home)
        {
            if (EProject.id == 0)
            {
                Home.Name = EProject.Name;
                Home.StDate = EProject.StDate;
                Home.HandDate = EProject.HandDate;
                Home.Status = EProject.Status;
                Home.Floor = EProject.Floor;
                Home.Electricity = EProject.Electricity;
                Home.Manager = EProject.Manager;
                Home.site = EProject.site;
                Home.Proid = EProject.Proid;
                Home.Comid = EProject.Comid;
                Home.Customerid = EProject.Customerid;
                Home.Sr = EProject.Sr;
                Home.WorkHours = EProject.WorkHours;
                _context.Add(Home);
                _context.Add(EProject);
                for (int i = 0; i < child.Count(); i++)
                {
                    var secname = _context.Section.Where(c => c.id == child[i]).Select(c => c.Name).SingleOrDefault();
                    _context.Database.ExecuteSqlRaw("INSERT  INTO EPchild (Secid, Name, Proid) VALUES ('" + child[i] + "','" + secname + "','" + EProject.Proid + "')");
                }
                TempData["Insert"] = "Submitted Successfully";
            }
            else
            {
                var Projectdb = _context.EProject.SingleOrDefault(c => c.Proid == EProject.Proid);
                _context.Database.ExecuteSqlRaw("Delete FROM EPchild WHERE (Proid='" + EProject.Proid + "')");
                Projectdb.Name = EProject.Name;
                Projectdb.StDate = EProject.StDate;
                Projectdb.HandDate = EProject.HandDate;
                //Projectdb.SuperVisor = EProject.SuperVisor;
                Projectdb.Manager = EProject.Manager;
                Projectdb.site = EProject.site;
                Projectdb.Customerid = EProject.Customerid;
                Projectdb.Comid = EProject.Comid;
                Projectdb.Electricity = EProject.Electricity;
                Projectdb.Floor = EProject.Floor;
                Projectdb.Sr = EProject.Sr;
                Projectdb.WorkHours = EProject.WorkHours;
                for (int i = 0; i < child.Count(); i++)
                {
                    var secname = _context.Section.Where(c => c.id == child[i]).Select(c => c.Name).SingleOrDefault();
                    _context.Database.ExecuteSqlRaw("INSERT  INTO EPchild (Secid, Name, Proid) VALUES ('" + child[i] + "','" + secname + "','" + EProject.Proid + "')");
                }
                TempData["update"] = "Updated Successfully";
            }
            _context.SaveChanges();
            return RedirectToAction("Indexx","Home");
        }
        public ActionResult Edit(int? id)
        {
            var viewModel = new Project_VM
            {
                EProject = _context.EProject.SingleOrDefault(c => c.Proid == id),
                EProjectchildList = _context.EPchild.Where(c => c.Proid == id).ToList(),
                SiteList = _context.Site.ToList(),
                MangerList = _context.DEmployee.Where(c => c.Designation == "1").ToList(),
                //SupervisorList = _context.DEmployee.Where(c => c.Designation == "2").ToList(),
                SectionList = _context.Section.ToList(),
                CompanyList = _context.Company.ToList(),
                CustomerList = _context.Customer.ToList(),
            };
            return View("Create", viewModel);
        }
        [HttpPost]
        public IActionResult SiteSave(Site Site)
        {
            _context.Add(Site);
            _context.SaveChanges();
            TempData["Insert"] = "Submitted Successfully";
            return RedirectToAction("Create");
        }
    }
}
