using ZkConstruction.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ZkConstruction.Data;
using ZkConstruction.Models;
using ZkConstruction.ViewModel;
using ZkConstruction.ViewModelQuery;

namespace ZkConstruction.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(new Repo<ProjectVMQS>().GetAllData("SELECT EProject.Name, EProject.StDate, EProject.HandDate, EProject.Proid, Site.Name AS Site FROM EProject INNER JOIN Site ON EProject.site = Site.id"));

        }
        public IActionResult Create(EProject EProject,EProjectchild EProjectchild)
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
                CustomerList= _context.Customer.ToList(),
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult save(EProject EProject,int[] child,Home Home)
        {
            string direction = "";
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
                    _context.Database.ExecuteSqlRaw("INSERT  INTO EPchild (Secid, Name, Proid) VALUES ('"+ child[i] +"','"+ secname + "','"+ EProject.Proid +"')");
                }
                TempData["Insert"] = "Submitted Successfully";
                direction = "Create";
            }
            else
            {
                var Projectdb = _context.EProject.SingleOrDefault(c => c.Proid == EProject.Proid);
                _context.Database.ExecuteSqlRaw("Delete FROM EPchild WHERE (Proid='"+ EProject.Proid +"')");
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
                direction = "Index";
            }
            _context.SaveChanges();
            return RedirectToAction(direction);
        }
        public ActionResult Edit(int? id)
        {
            var viewModel = new Project_VM
            {
                EProject = _context.EProject.SingleOrDefault(c => c.Proid == id),
                EProjectchildList= _context.EPchild.Where(c => c.Proid == id).ToList(),
                SiteList = _context.Site.ToList(),
                MangerList = _context.DEmployee.Where(c => c.Designation == "1").ToList(),
                //SupervisorList = _context.DEmployee.Where(c => c.Designation == "2").ToList(),
                SectionList = _context.Section.ToList(),
                CompanyList = _context.Company.ToList(),
                CustomerList = _context.Customer.ToList(),
            };
            return View("Create", viewModel);
        }
        public IActionResult Delete(int id)
        {
            var Project = _context.EProject.SingleOrDefault(c => c.Proid == id);
            _context.Database.ExecuteSqlRaw("DELETE FROM EPchild WHERE (Proid = "+ id +")");
            //var PChild = _context.EPchild.SingleOrDefault(c => c.Proid == id);
            _context.Remove(Project);
            //_context.Remove(PChild);
            _context.SaveChanges();
            TempData["Delete"] = "Deleted Successfully";
            return RedirectToAction("Index");
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
