using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.Data;
using ZkConstruction.Models;

namespace ZkConstruction.Controllers
{
    public class HomeEditController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment host;
        public HomeEditController(ApplicationDbContext context, IWebHostEnvironment host)
        {
            _context = context;
            this.host = host;
        }

        [HttpPost]
        public IActionResult UpFlooringSave(Documents Documents, int Proid)
        {
            Random r = new Random();
            int num = r.Next();
            var webrootpath = host.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            for (int i = 0; i < files.Count(); i++) 
                {
                    var uploads = Path.Combine(webrootpath, "Uploads");
                    var filename = Path.GetFileName(files[i].FileName);
                    using (var stream = new FileStream(Path.Combine(uploads, num + filename), FileMode.Create))
                    {
                        files[i].CopyTo(stream);
                    }
                if (files[i].Name == "Documents.Img")
                {
                    Documents.Img = num + filename;
                }
                _context.Database.ExecuteSqlRaw("INSERT INTO Documents (Proid,Img,Type) VALUES ("+ Proid +",'"+ Documents.Img +"','FlooringDoc')");
                }
            TempData["Update"] = "Uploaded Successfully";
            return RedirectToAction("Indexx","Home");
        }
        [HttpPost]
        public IActionResult UpProSave(Documents Documents, int Proid)
        {
            Random r = new Random();
            int num = r.Next();
            var webrootpath = host.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            for (int i = 0; i < files.Count(); i++) 
                {
                    var uploads = Path.Combine(webrootpath, "Uploads");
                    var filename = Path.GetFileName(files[i].FileName);
                    using (var stream = new FileStream(Path.Combine(uploads, num + filename), FileMode.Create))
                    {
                        files[i].CopyTo(stream);
                    }
                if (files[i].Name == "Documents.Img")
                {
                    Documents.Img = num + filename;
                }
                _context.Database.ExecuteSqlRaw("INSERT INTO Documents (Proid,Img,Type) VALUES ("+ Proid +",'"+ Documents.Img +"','ProjectDoc')");
                }
            TempData["Update"] = "Uploaded Successfully";
            return RedirectToAction("Indexx","Home");
        }
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
        public IActionResult FlStDateSave(string StTime, int Proid)
        {
            _context.Database.ExecuteSqlRaw("Update Home Set StdateTimeFlooring = '" + StTime + "' WHERE (Proid = " + Proid + ")");
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
        public IActionResult PaEmAddSave(int[] Empid, int Proid,string type, string[] CloseDt, int[] AllEmp,int Siteid)
        {
            _context.Database.ExecuteSqlRaw("DELETE FROM EmployeeAssigned WHERE (Type = '"+ type +"') AND (Proid = "+ Proid +")");
            for (int i = 0; i < AllEmp.Count(); i++)
            {
                for (int j = 0; j < Empid.Count(); j++)
                {
                    if (AllEmp[i] == Empid[j])
                    {
                        _context.Database.ExecuteSqlRaw("INSERT INTO EmployeeAssigned(Proid, Employeeid, Type,CloseDateTime,Siteid) VALUES ('" + Proid + "','" + AllEmp[i] + "','" + type + "','" + CloseDt[i] + "','"+ Siteid +"')");
                    }
                }
            }
            TempData["Update"] = "Inserted Successfully";
            return RedirectToAction("Indexx", "Home");
        }
        [HttpPost]
        public IActionResult FlEmAddSave(int[] Empid, int Proid,string type ,string[] CloseDt,int [] AllEmp, int Siteid)
        {
            _context.Database.ExecuteSqlRaw("DELETE FROM EmployeeAssigned WHERE (Type = '"+ type +"') AND (Proid = "+ Proid +")");
            for (int i = 0; i < AllEmp.Count(); i++)
            {
                for (int j = 0; j < Empid.Count(); j++)
                {
                    if (AllEmp[i] == Empid[j])
                    {
                        _context.Database.ExecuteSqlRaw("INSERT INTO EmployeeAssigned(Proid, Employeeid, Type,CloseDateTime,Siteid) VALUES ('" + Proid + "','" + AllEmp[i] + "','" + type + "','" + CloseDt[i] + "','" + Siteid + "')");
                    }
                }
            }
            TempData["Update"] = "Inserted Successfully";
            return RedirectToAction("Indexx", "Home");
        }
        [HttpPost]
        public IActionResult FlClosingSave(string[] Empid, int Proid,string type ,string[] CloseDt)
        {
            for (int i = 0; i < CloseDt.Count(); i++)
            {
                if (CloseDt[i] != null)
                {
                    _context.Database.ExecuteSqlRaw("UPDATE EmployeeAssigned SET CloseDateTime ='" + CloseDt[i] +"' WHERE (Proid = "+ Proid +") AND (Type = '"+ type +"') AND (Employeeid = "+ Empid[i] +")");
                }
            }
            TempData["Update"] = "Inserted Successfully";
            return RedirectToAction("Indexx", "Home");
        }
        [HttpPost]
        public IActionResult PaClosingSave(string[] Empid, int Proid,string type ,string[] CloseDt)
        {
            for (int i = 0; i < CloseDt.Count(); i++)
            {
                if (CloseDt[i] != null)
                {
                    _context.Database.ExecuteSqlRaw("UPDATE EmployeeAssigned SET CloseDateTime ='" + CloseDt[i] +"' WHERE (Proid = "+ Proid +") AND (Type = '"+ type +"') AND (Employeeid = "+ Empid[i] +")");
                }
            }
            TempData["Update"] = "Inserted Successfully";
            return RedirectToAction("Indexx", "Home");
        }
        [HttpPost]
        public IActionResult PastartSave(string[] Empid, int Proid,string type ,string[] StartDt)
        {
            for (int i = 0; i < StartDt.Count(); i++)
            {
                if (StartDt[i] != null)
                {
                    _context.Database.ExecuteSqlRaw("UPDATE EmployeeAssigned SET StartDateTime ='" + StartDt[i] +"' WHERE (Proid = "+ Proid +") AND (Type = '"+ type +"') AND (Employeeid = "+ Empid[i] +")");
                }
            }
            TempData["Update"] = "Inserted Successfully";
            return RedirectToAction("Indexx", "Home");
        }
        [HttpPost]
        public IActionResult FlStartSave(string[] Empid, int Proid,string type ,string[] StartDt)
        {
            for (int i = 0; i < StartDt.Count(); i++)
            {
                if (StartDt[i] != null)
                {
                    _context.Database.ExecuteSqlRaw("UPDATE EmployeeAssigned SET StartDateTime ='" + StartDt[i] +"' WHERE (Proid = "+ Proid +") AND (Type = '"+ type +"') AND (Employeeid = "+ Empid[i] +")");
                }
            }
            TempData["Update"] = "Inserted Successfully";
            return RedirectToAction("Indexx", "Home");
        }
        [HttpPost]
        public IActionResult DelieveryStatus(string Status, int Proid)
        {
            _context.Database.ExecuteSqlRaw("Update Home Set DelieveryStatus = '" + Status + "' WHERE (Proid = " + Proid + ")");
            TempData["Update"] = "Updated Successfully";
            return RedirectToAction("Indexx", "Home");
        }
    }
}
