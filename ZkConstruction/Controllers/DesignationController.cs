using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.Data;
using ZkConstruction.Models;

namespace ZkConstruction.Controllers
{
    public class DesignationController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DesignationController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Designation.OrderByDescending(c => c.id).ToList());
        }
        public IActionResult Create(Designation Designation)
        {
            return View(Designation);
        }
        [HttpPost]
        public IActionResult save(Designation Designation)
        {
            string direction = "";
            if (Designation.id == 0)
            {
                _context.Add(Designation);
                TempData["Insert"] = "Submitted Successfully";
                direction = "Create";
            }
            else
            {
                var db = _context.Designation.SingleOrDefault(c => c.id == Designation.id);
                db.Name = Designation.Name;
                TempData["update"] = "Updated Successfully";
                direction = "Index";
            }
            _context.SaveChanges();
            return RedirectToAction(direction);
        }
        public ActionResult Edit(int? id)
        {
            var listed = _context.Designation.SingleOrDefault(c => c.id == id);
            return View("Create", listed);
        }
        public IActionResult Delete(int id)
        {
            var lst = _context.Designation.SingleOrDefault(c => c.id == id);
            _context.Remove(lst);
            _context.SaveChanges();
            TempData["Delete"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
