using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Mvc;
using ZkConstruction.Data;
using ZkConstruction.Data.Repository;
using ZkConstruction.Models;
using ZkConstruction.ViewModel;
using ZkConstruction.ViewModelQuery;

namespace ZkConstruction.Controllers
{
    public class AssignProjectController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AssignProjectController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(new Repo<ProjectAssignVMQ>().GetAllData("SELECT ProjectAssign.id, ProjectAssign.StDate, ProjectAssign.EnDate, ProjectAssign.Assignid, EProject.Name AS ProjectName, Section.Name AS SecName FROM ProjectAssign INNER JOIN EProject ON ProjectAssign.Projectid = EProject.Proid INNER JOIN Section ON ProjectAssign.Secid = Section.id").ToList());
        }
        public IActionResult Create(ProjectAssign projectAssign)
        {
            if (_context.ProjectAssign.Count() == 0)
            {
                projectAssign.Assignid = 1;
            }
            else
            {
                projectAssign.Assignid = _context.ProjectAssign.Max(x => x.Assignid) + 1;
            }
            var viewmodel = new Assign_VM
            {
                ProjectList = _context.EProject.ToList(),
                EmployeeList = new Repo<DEmployee>().GetAllData("SELECT DEmployee.id, DEmployee.AccountNo, DEmployee.Name, DEmployee.Email, DEmployee.Mobile, DEmployee.City, DEmployee.Country, DEmployee.Address, DEmployee.DOB, DEmployee.DOJ, DEmployee.PerHourSalary, Designation.Name AS Designation FROM DEmployee INNER JOIN Designation ON DEmployee.Designation = Designation.id").ToList(),
                SectionList = _context.Section.ToList(),
                projectAssign=projectAssign
            };
            return View(viewmodel);
        }
        [HttpGet]
        public JsonResult ProductList(int id)
        {
            return Json(_context.EPchild.Where(c => c.Proid == id).ToList());
        }
        [HttpGet]
        public JsonResult SubSection(int id)
        {
            return Json(_context.SubSection.Where(c => c.Sectionid == id).ToList());
        }
        public IActionResult save(ProjectAssign projectAssign , string[] child)
        {
            string direction = "";
            if (projectAssign.id == 0)
            {
                for (int i = 0; i < child.Count(); i++)
                {
                    _context.Database.ExecuteSqlRaw("INSERT INTO Assignchild (Assignid, EmployeeAcc) VALUES ('"+ projectAssign.Assignid +"','"+ child[i] +"')");
                }
                _context.Add(projectAssign);
                TempData["Insert"] = "Submitted Successfully";
                direction = "Create";
            }
            else
            {
                var db = _context.ProjectAssign.SingleOrDefault(c => c.id == projectAssign.id);
                db.Projectid = projectAssign.Projectid;
                db.Secid = projectAssign.Secid;
                db.StDate = projectAssign.StDate;
                db.EnDate = projectAssign.EnDate;
                db.SubSecid = projectAssign.SubSecid;
                db.Assignid = projectAssign.Assignid;
                _context.Database.ExecuteSqlRaw("DELETE FROM Assignchild WHERE (Assignid="+ projectAssign.Assignid +")");
                for (int i = 0; i < child.Count(); i++)
                {
                    _context.Database.ExecuteSqlRaw("INSERT INTO Assignchild (Assignid, EmployeeAcc) VALUES ('" + projectAssign.Assignid + "','" + child[i] + "')");
                }
                TempData["update"] = "Updated Successfully";
                direction = "Index";
            }
            _context.SaveChanges();
            return RedirectToAction(direction);
        }
        public ActionResult Edit(int? id)
        {
            var prop = _context.ProjectAssign.SingleOrDefault(c => c.Assignid == id);
            var viewModel = new Assign_VM
            {
                projectAssign = prop,
                ProjectList = _context.EProject.ToList(),
                EmployeeList = new Repo<DEmployee>().GetAllData("SELECT DEmployee.id, DEmployee.AccountNo, DEmployee.Name, DEmployee.Email, DEmployee.Mobile, DEmployee.City, DEmployee.Country, DEmployee.Address, DEmployee.DOB, DEmployee.DOJ, DEmployee.PerHourSalary, Designation.Name AS Designation FROM DEmployee INNER JOIN Designation ON DEmployee.Designation = Designation.id").ToList(),
                ProjectchildList = _context.EPchild.FromSqlRaw("SELECT * FROM EPchild WHERE (Proid = '" + prop.Projectid + "')").ToList(),
                SubsectionList = _context.SubSection.FromSqlRaw("SELECT * FROM SubSection WHERE(Sectionid = '" + prop.Secid + "')").ToList(),
                AssignchildList = _context.Assignchild.Where(c => c.Assignid == id).ToList(),
            };
            return View("Create", viewModel);
        }
        public IActionResult Delete(int id)
        {
            var Project = _context.ProjectAssign.SingleOrDefault(c => c.Assignid == id);
            _context.Remove(Project);
            _context.SaveChanges();
            TempData["Delete"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
