using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.Data;
using ZkConstruction.Models;

namespace ZkConstruction.Controllers
{
    public class SiteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SiteController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Site.OrderByDescending(c => c.id).ToList());
        }
        public IActionResult Create(Site site)
        {
            return View(site);
        }
        [HttpPost]
        public IActionResult save(Site site)
        {
            string direction = "";
            if (site.id == 0)
            {
                _context.Add(site);
                TempData["Insert"] = "Submitted Successfully";
                direction = "Create";
            }
            else
            {
                var db = _context.Site.SingleOrDefault(c => c.id == site.id);
                db.Name = site.Name;
                db.Detail = site.Detail;
                TempData["update"] = "Updated Successfully";
                direction = "Index";
            }
            _context.SaveChanges();
            return RedirectToAction(direction);
        }
        public ActionResult Edit(int? id)
        {
            var listed = _context.Site.SingleOrDefault(c => c.id == id);
            return View("Create", listed);
        }
        public IActionResult Delete(int id)
        {
            var lst = _context.Site.SingleOrDefault(c => c.id == id);
            _context.Remove(lst);
            _context.SaveChanges();
            TempData["Delete"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
