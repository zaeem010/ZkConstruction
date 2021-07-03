using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.Data;
using ZkConstruction.Data.Repository;
using ZkConstruction.Models;
using ZkConstruction.ViewModel;
using ZkConstruction.ViewModelQuery;

namespace ZkConstruction.Controllers
{
    public class AppSiteVisitController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment host;
        public AppSiteVisitController(ApplicationDbContext context, IWebHostEnvironment host)
        {
            _context = context;
            this.host = host;
        }
        public IActionResult Index()
        {
            return View(new Repo<SiteVisitVMQ>().GetAllData("SELECT Sitevisit.Visitid, Sitevisit.Date, EProject.Name AS ProjectName, DEmployee.Name AS Surveyor, Site.Name AS SiteName FROM Sitevisit INNER JOIN EProject ON Sitevisit.Projectid = EProject.Proid INNER JOIN DEmployee ON Sitevisit.Surveyor = DEmployee.AccountNo INNER JOIN Site ON Sitevisit.Siteid = Site.id").ToList());
        }
        public IActionResult Create(Sitevisit sitevisit)
        {
            if (_context.Sitevisit.Count() == 0)
            {
                sitevisit.Visitid = 1;
            }
            else
            {
                sitevisit.Visitid = _context.Sitevisit.Max(x => x.Visitid) + 1;
            }
            var viewmodel = new SiteVisit_VM
            {
                ProjectList = _context.EProject.ToList(),
                SiteList = _context.Site.ToList(),
                EmployeeList = _context.DEmployee.Where(c => c.Designation == "4").ToList(),
                Sitevisit = sitevisit,
            };
            return View(viewmodel);
        }
        [HttpPost]
        public IActionResult save(Sitevisit Sitevisit, SitevisitImage sitevisitImage)
        {
            string direction = "";
            //Multi images
            Random r = new Random();
            int num = r.Next();
            var webrootpath = host.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            if (Sitevisit.id == 0)
            {
                if (files.Count > 0)
                {
                    for (int i = 0; i < files.Count(); i++)
                    {
                        var uploads = Path.Combine(webrootpath, "Uploads");
                        var filename = Path.GetFileName(files[i].FileName);
                        using (var stream = new FileStream(Path.Combine(uploads, num + Sitevisit.Visitid + filename), FileMode.Create))
                        {
                            files[i].CopyTo(stream);
                        }
                        sitevisitImage.Image = num + Sitevisit.Visitid + filename;
                        _context.Database.ExecuteSqlRaw("INSERT INTO  SitevisitImage(Visitid, Image) VALUES ('" + Sitevisit.Visitid + "','" + sitevisitImage.Image + "')");
                    }
                }
                _context.Add(Sitevisit);
                TempData["Insert"] = "Submitted Successfully";
                direction = "Create";
            }
            else
            {
                var db = _context.Sitevisit.SingleOrDefault(c => c.Visitid == Sitevisit.Visitid);
                db.Projectid = Sitevisit.Projectid;
                db.Siteid = Sitevisit.Siteid;
                db.Surveyor = Sitevisit.Surveyor;
                db.Date = Sitevisit.Date;
                db.Area = Sitevisit.Area;
                if (files.Count > 0)
                {
                    for (int i = 0; i < files.Count(); i++)
                    {
                        var uploads = Path.Combine(webrootpath, "Uploads");
                        var filename = Path.GetFileName(files[i].FileName);
                        using (var stream = new FileStream(Path.Combine(uploads, num + Sitevisit.Visitid + filename), FileMode.Create))
                        {
                            files[i].CopyTo(stream);
                        }
                        sitevisitImage.Image = num + Sitevisit.Visitid + filename;
                        _context.Database.ExecuteSqlRaw("INSERT INTO  SitevisitImage(Visitid, Image) VALUES ('" + Sitevisit.Visitid + "','" + sitevisitImage.Image + "')");
                    }
                }
                TempData["update"] = "Updated Successfully";
                direction = "Index";
            }
            _context.SaveChanges();
            return RedirectToAction(direction);
        }
        public ActionResult Edit(int? id)
        {
            var viewmodel = new SiteVisit_VM
            {
                Sitevisit = _context.Sitevisit.SingleOrDefault(c => c.Visitid == id),
                ProjectList = _context.EProject.ToList(),
                SiteList = _context.Site.ToList(),
                EmployeeList = _context.DEmployee.Where(c => c.Designation == "4").ToList(),
            };
            return View("Create", viewmodel);
        }
        public IActionResult Delete(int id)
        {
            var sitevisit = _context.Sitevisit.SingleOrDefault(c => c.Visitid == id);
            _context.Database.ExecuteSqlRaw("DELETE FROM SitevisitImage WHERE (Visitid =" + id + ")");
            _context.Remove(sitevisit);
            _context.SaveChanges();
            TempData["Delete"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
