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
    public class WorkSheetController : Controller
    {
        private readonly ApplicationDbContext _context;
        public WorkSheetController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(new Repo<WorksheetVMQ>().GetAllData("SELECT Worksheet.id, Worksheet.Date, Worksheet.CompanyName, Worksheet.SiteAddress, Worksheet.AccoummodationNo, Worksheet.ProviderOrderNo, Worksheet.FloorSide, Site.Name AS SiteName, EProject.Name AS ProjectName FROM Worksheet INNER JOIN Site ON Worksheet.Siteid = Site.id INNER JOIN EProject ON Worksheet.Proid = EProject.Proid").ToList());
        }
        public IActionResult Create(Worksheet WorkSheet)
        {
            var Projects = _context.EProject.ToList();
            var Sites = _context.Site.ToList();
            var VM = new WorkSheetVM
            {
                WorkSheet = WorkSheet,
                ProjectList = Projects,
                SiteList = Sites
            };
            return View(VM);
        }
        public IActionResult Creates(Worksheet Worksheet)
        {
            var Projects = _context.EProject.ToList();
            var Sites = _context.Site.ToList();
            var db = _context.Worksheet.FromSqlRaw("SELECT * FROM Worksheet WHERE (Proid = "+ Worksheet.Proid +") AND (Siteid = "+ Worksheet.Siteid +")").SingleOrDefault();
            if (db != null)
            {
                Worksheet = db;
            }
            else
            {
#pragma warning disable CS1717 // Assignment made to same variable
                Worksheet = Worksheet;
#pragma warning restore CS1717 // Assignment made to same variable
            };
            var VM = new WorkSheetVM
            {
                WorkSheet=Worksheet,
                ProjectList = Projects,
                SiteList = Sites
            };
            return View(VM);
        }
        [HttpPost]
        public IActionResult Save(Worksheet Worksheet)
        {
            var dr = "";
            if (Worksheet.id ==0)
            {
                _context.Worksheet.Add(Worksheet);
                TempData["Insert"] = "Query Executed Successfully...";
                dr = "Create";
            }
            else
            {
                var db = _context.Worksheet.SingleOrDefault(c => c.id == Worksheet.id) ;
                db.Date = Worksheet.Date;
                db.Proid = Worksheet.Proid;
                db.CompanyName = Worksheet.CompanyName;
                db.SiteAddress = Worksheet.SiteAddress;
                db.FloorSide = Worksheet.FloorSide;
                db.ProviderOrderNo = Worksheet.ProviderOrderNo;
                db.AccoummodationNo = Worksheet.AccoummodationNo;
                db.EntranceNovi = Worksheet.EntranceNovi;
                db.EntranceMod = Worksheet.EntranceMod;
                db.ClearenceNovi = Worksheet.ClearenceNovi;
                db.ClearenceModi = Worksheet.ClearenceModi;
                db.BedNovi = Worksheet.BedNovi;
                db.BedMod = Worksheet.BedMod;
                db.Room1Novi = Worksheet.Room1Novi;
                db.Room1Mod = Worksheet.Room1Mod;
                db.Room2Novi = Worksheet.Room2Novi;
                db.Room2Mod = Worksheet.Room2Mod;
                db.CellarNovi = Worksheet.CellarNovi;
                db.CellarMod = Worksheet.CellarMod;
                db.CookNovi = Worksheet.CookNovi;
                db.CookMod = Worksheet.CookMod;
                db.RoomBathNovi = Worksheet.RoomBathNovi;
                db.RoomBathMod = Worksheet.RoomBathMod;
                db.FirmToiletNovi = Worksheet.FirmToiletNovi;
                db.FirmToiletMod = Worksheet.FirmToiletMod;
                db.WCNovi = Worksheet.WCNovi;
                db.WCMod = Worksheet.WCMod;
                db.WoodPlinth5 = Worksheet.WoodPlinth5;
                db.WoodPlinth10 = Worksheet.WoodPlinth10;
                db.LevelCompund = Worksheet.LevelCompund;
                db.SILICONE = Worksheet.SILICONE;
                db.Deatil1 = Worksheet.Deatil1;
                db.EDL = Worksheet.EDL;
                TempData["Update"] = "Updated Successfully...";
                dr = "Index";
            }
            _context.SaveChanges();
            return RedirectToAction(dr);
        }
    }
}
