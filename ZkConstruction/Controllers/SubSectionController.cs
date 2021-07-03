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
    public class SubSectionController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SubSectionController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(new Repo<subsecVMQ>().GetAllData("SELECT SubSection.id, SubSection.Name, Section.Name AS SectionName FROM SubSection INNER JOIN Section ON SubSection.Sectionid = Section.id").ToList());
        }
        public IActionResult Create(Subsection Subsection)
        {
            var viewmodel = new SubSec_VM
            {
                SectionList=_context.Section.ToList(),
                Subsection=Subsection
            };
            return View(viewmodel);
        }
        [HttpPost]
        public IActionResult save(Subsection Subsection)
        {
            string direction = "";
            if (Subsection.id == 0)
            {
                _context.Add(Subsection);
                TempData["Insert"] = "Submitted Successfully";
                direction = "Create";
            }
            else
            {
                var db = _context.SubSection.SingleOrDefault(c => c.id == Subsection.id);
                db.Name = Subsection.Name;
                db.Sectionid = Subsection.Sectionid;
                TempData["update"] = "Updated Successfully";
                direction = "Index";
            }
            _context.SaveChanges();
            return RedirectToAction(direction);
        }
        public ActionResult Edit(int? id)
        {
            var viewmodel = new SubSec_VM
            {
                Subsection = _context.SubSection.SingleOrDefault(c => c.id == id),
                SectionList = _context.Section.ToList()
            };
            return View("Create",viewmodel);
        }
        public IActionResult Delete(int id)
        {
            var lst = _context.SubSection.SingleOrDefault(c => c.id == id);
            _context.Remove(lst);
            _context.SaveChanges();
            TempData["Delete"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
