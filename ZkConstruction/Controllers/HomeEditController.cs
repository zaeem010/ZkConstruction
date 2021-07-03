using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.Data;

namespace ZkConstruction.Controllers
{
    public class HomeEditController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeEditController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult ComSave(string Com ,int Proid)
        {
            _context.Database.ExecuteSqlRaw("Update Eproject Set Comid = '"+ Com +"' WHERE (Proid = "+ Proid +")");
            _context.Database.ExecuteSqlRaw("Update Home Set Comid = '"+ Com +"' WHERE (Proid = "+ Proid +")");
            TempData["Update"] = "Updated Successfully";
            return RedirectToAction("Indexx","Home");
        }
        [HttpPost]
        public IActionResult SrSave(string Sr ,int Proid)
        {
            _context.Database.ExecuteSqlRaw("Update Eproject Set Sr = '"+ Sr + "' WHERE (Proid = "+ Proid +")");
            _context.Database.ExecuteSqlRaw("Update Home Set Sr = '"+ Sr + "' WHERE (Proid = "+ Proid +")");
            TempData["Update"] = "Updated Successfully";
            return RedirectToAction("Indexx","Home");
        }
        [HttpPost]
        public IActionResult SiteSave(string Site, int Proid)
        {
            _context.Database.ExecuteSqlRaw("Update Eproject Set site = '" + Site + "' WHERE (Proid = "+ Proid +")");
            _context.Database.ExecuteSqlRaw("Update Home Set site = '" + Site + "' WHERE (Proid = "+ Proid +")");
            TempData["Update"] = "Updated Successfully";
            return RedirectToAction("Indexx","Home");
        }
        [HttpPost]
        public IActionResult FloorSave(string Floor, int Proid)
        {
            _context.Database.ExecuteSqlRaw("Update Eproject Set Floor = '" + Floor + "' WHERE (Proid = "+ Proid +")");
            _context.Database.ExecuteSqlRaw("Update Home Set Floor = '" + Floor + "' WHERE (Proid = "+ Proid +")");
            TempData["Update"] = "Updated Successfully";
            return RedirectToAction("Indexx","Home");
        }
        [HttpPost]
        public IActionResult CusSave(string Cus, int Proid)
        {
            _context.Database.ExecuteSqlRaw("Update Eproject Set Customerid = '" + Cus + "' WHERE (Proid = "+ Proid +")");
            _context.Database.ExecuteSqlRaw("Update Home Set Customerid = '" + Cus + "' WHERE (Proid = "+ Proid +")");
            TempData["Update"] = "Updated Successfully";
            return RedirectToAction("Indexx","Home");
        }
        [HttpPost]
        public IActionResult WorkSave(string Work, int Proid)
        {
            _context.Database.ExecuteSqlRaw("Update Eproject Set WorkHours = '" + Work + "' WHERE (Proid = "+ Proid +")");
            _context.Database.ExecuteSqlRaw("Update Home Set WorkHours = '" + Work + "' WHERE (Proid = "+ Proid +")");
            TempData["Update"] = "Updated Successfully";
            return RedirectToAction("Indexx","Home");
        }
        [HttpPost]
        public IActionResult HandSave(string Hand, int Proid)
        {
            _context.Database.ExecuteSqlRaw("Update Eproject Set HandDate = '" + Hand + "' WHERE (Proid = "+ Proid +")");
            _context.Database.ExecuteSqlRaw("Update Home Set HandDate = '" + Hand + "' WHERE (Proid = "+ Proid +")");
            TempData["Update"] = "Updated Successfully";
            return RedirectToAction("Indexx","Home");
        }
        [HttpPost]
        public IActionResult ElSave(string El, int Proid)
        {
            _context.Database.ExecuteSqlRaw("Update Eproject Set Electricity = '" + El + "' WHERE (Proid = "+ Proid +")");
            _context.Database.ExecuteSqlRaw("Update Home Set Electricity = '" + El + "' WHERE (Proid = "+ Proid +")");
            TempData["Update"] = "Updated Successfully";
            return RedirectToAction("Indexx","Home");
        }
        [HttpPost]
        public IActionResult StSave(string St, int Proid)
        {
            _context.Database.ExecuteSqlRaw("Update Eproject Set StDate = '" + St + "' WHERE (Proid = "+ Proid +")");
            _context.Database.ExecuteSqlRaw("Update Home Set StDate = '" + St + "' WHERE (Proid = "+ Proid +")");
            TempData["Update"] = "Updated Successfully";
            return RedirectToAction("Indexx","Home");
        }
        [HttpPost]
        public IActionResult ManagerSave(string Manager, int Proid)
        {
            _context.Database.ExecuteSqlRaw("Update Eproject Set Manager = '" + Manager + "' WHERE (Proid = "+ Proid +")");
            _context.Database.ExecuteSqlRaw("Update Home Set Manager = '" + Manager + "' WHERE (Proid = "+ Proid +")");
            TempData["Update"] = "Updated Successfully";
            return RedirectToAction("Indexx","Home");
        }
        [HttpPost]
        public IActionResult PaintSave(string Pa, int Proid,int Secid)
        {
            _context.Database.ExecuteSqlRaw("DELETE FROM EPchild WHERE (Proid = "+ Proid +") AND (Secid = "+ Secid +")");
            if (Pa == "Yes")
            {
                _context.Database.ExecuteSqlRaw("Insert into EPchild (Secid,Name,Proid) VALUES ('"+ Secid + "' ,'Painting',"+ Proid +") ");
            }
            else { 
            }
            TempData["Update"] = "Updated Successfully";
            return RedirectToAction("Indexx","Home");
        }
        [HttpPost]
        public IActionResult FlooringSave(string Fl, int Proid,int Secid)
        {
            _context.Database.ExecuteSqlRaw("DELETE FROM EPchild WHERE (Proid = "+ Proid +") AND (Secid = "+ Secid +")");
            if (Fl == "Yes")
            {
                _context.Database.ExecuteSqlRaw("Insert into EPchild (Secid,Name,Proid) VALUES ('"+ Secid + "' ,'Flooring',"+ Proid +") ");
            }
            else { 
            }
            TempData["Update"] = "Updated Successfully";
            return RedirectToAction("Indexx","Home");
        }
        [HttpPost]
        public IActionResult WallpaperSave(string Wa, int Proid,int Secid)
        {
            _context.Database.ExecuteSqlRaw("DELETE FROM EPchild WHERE (Proid = "+ Proid +") AND (Secid = "+ Secid +")");
            if (Wa == "Yes")
            {
                _context.Database.ExecuteSqlRaw("Insert into EPchild (Secid,Name,Proid) VALUES ('"+ Secid + "' ,'Wallpaper'," + Proid +") ");
            }
            else { 
            }
            TempData["Update"] = "Updated Successfully";
            return RedirectToAction("Indexx","Home");
        }
        [HttpPost]
        public IActionResult CleaningSave(string Cl, int Proid,int Secid)
        {
            _context.Database.ExecuteSqlRaw("DELETE FROM EPchild WHERE (Proid = "+ Proid +") AND (Secid = "+ Secid +")");
            if (Cl == "Yes")
            {
                _context.Database.ExecuteSqlRaw("Insert into EPchild (Secid,Name,Proid) VALUES ('"+ Secid + "' ,'Cleaning'," + Proid +") ");
            }
            else { 
            }
            TempData["Update"] = "Updated Successfully";
            return RedirectToAction("Indexx","Home");
        }
        [HttpPost]
        public IActionResult PaintHoursSave(string PaintHours, int Proid)
        {
            _context.Database.ExecuteSqlRaw("Update Home Set PaintingHours = '" + PaintHours + "' WHERE (Proid = " + Proid + ")");
            TempData["Update"] = "Updated Successfully";
            return RedirectToAction("Indexx", "Home");
        }
        [HttpPost]
        public IActionResult StTimeSave(string StTime, int Proid)
        {
            _context.Database.ExecuteSqlRaw("Update Home Set StTime = '" + StTime + "' WHERE (Proid = " + Proid + ")");
            TempData["Update"] = "Updated Successfully";
            return RedirectToAction("Indexx", "Home");
        }
        [HttpPost]
        public IActionResult FlHoursSave(string FlHours, int Proid)
        {
            _context.Database.ExecuteSqlRaw("Update Home Set FlooringHours = '" + FlHours + "' WHERE (Proid = " + Proid + ")");
            TempData["Update"] = "Updated Successfully";
            return RedirectToAction("Indexx", "Home");
        }
        [HttpPost]
        public IActionResult FlRoomSave(string FlRoom, int Proid)
        {
            _context.Database.ExecuteSqlRaw("Update Home Set FlooringRoom = '" + FlRoom + "' WHERE (Proid = " + Proid + ")");
            TempData["Update"] = "Updated Successfully";
            return RedirectToAction("Indexx", "Home");
        }
        [HttpPost]
        public IActionResult RmHoursSave(string RmHours, int Proid)
        {
            _context.Database.ExecuteSqlRaw("Update Home Set RemainingHours = '" + RmHours + "' WHERE (Proid = " + Proid + ")");
            TempData["Update"] = "Updated Successfully";
            return RedirectToAction("Indexx", "Home");
        }
        [HttpPost]
        public IActionResult PaEmAddSave(string[] Empid, int Proid,string type)
        {
            _context.Database.ExecuteSqlRaw("DELETE FROM EmployeeAssigned WHERE (Type = '"+ type +"') AND (Proid = "+ Proid +")");
            for (int i = 0; i < Empid.Count(); i++)
            {
                _context.Database.ExecuteSqlRaw("INSERT INTO EmployeeAssigned(Proid, Employeeid, Type) VALUES ('" + Proid + "','" + Empid[i] + "','" + type + "')");
            }
            TempData["Update"] = "Inserted Successfully";
            return RedirectToAction("Indexx", "Home");
        }
        [HttpPost]
        public IActionResult FlEmAddSave(string[] Empid, int Proid,string type)
        {
            _context.Database.ExecuteSqlRaw("DELETE FROM EmployeeAssigned WHERE (Type = '"+ type +"') AND (Proid = "+ Proid +")");
            for (int i = 0; i < Empid.Count(); i++)
            {
                _context.Database.ExecuteSqlRaw("INSERT INTO EmployeeAssigned(Proid, Employeeid, Type) VALUES ('" + Proid + "','" + Empid[i] + "','" + type + "')");
            }
            TempData["Update"] = "Inserted Successfully";
            return RedirectToAction("Indexx", "Home");
        }
    }
}
