using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.Data;
using ZkConstruction.Models;

namespace ZkConstruction.Controllers
{
    public class SectionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SectionController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Section.OrderByDescending(c => c.id).ToList());
        }
        public IActionResult Create(Section section)
        {
            return View(section);
        }
        [HttpPost]
        public IActionResult save(Section section)
        {
            string direction = "";
            if (section.id == 0)
            {
                _context.Add(section);
                TempData["Insert"] = "Submitted Successfully";
                direction = "Create";
            }
            else
            {
                var db = _context.Section.SingleOrDefault(c => c.id == section.id);
                db.Name = section.Name;
                db.Detail = section.Detail;
                TempData["update"] = "Updated Successfully";
                direction = "Index";
            }
            _context.SaveChanges();
            return RedirectToAction(direction);
        }
        public ActionResult Edit(int? id)
        {
            var listed = _context.Section.SingleOrDefault(c => c.id == id);
            return View("Create", listed);
        }
        public IActionResult Delete(int id)
        {
            var lst = _context.Section.SingleOrDefault(c => c.id == id);
            _context.Remove(lst);
            _context.SaveChanges();
            TempData["Delete"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
