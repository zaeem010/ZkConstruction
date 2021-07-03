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
    public class StockOrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StockOrderController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var List = new Repo<STOVMQ>().GetAllData("SELECT STOMaster.Status,STOMaster.DateOrder, STOMaster.RequiredDate, STOMaster.Invid, DEmployee.Name, Site.Name AS SiteName FROM STOMaster INNER JOIN DEmployee ON STOMaster.DelieverPerson = DEmployee.AccountNo INNER JOIN Site ON STOMaster.Siteid = Site.id").ToList();
            return View(List);
        }
        public IActionResult Create(STOMaster STOMaster)
        {
            var ProductList = _context.Product.ToList();
            var SiteList = _context.Site.ToList();
            var EmployeeList = _context.DEmployee.ToList();
            var ViewModel = new STOVM
            {
                STOMaster = STOMaster,
                ProductList=ProductList,
                SiteList=SiteList,
                EmployeeList=EmployeeList,
            };
            return View(ViewModel);
        }
        [HttpGet]
        public JsonResult Itemid(int id)
        {
            return Json(_context.Product.SingleOrDefault(c => c.id == id));
        }
       [HttpPost]
        public IActionResult Save(STOMaster STOMaster ,int[] Itemid ,int[] Qty,decimal[] Cp,decimal[] Total,string[] ItemName)
        {
            string dir = "";
            if (STOMaster.id == 0)
            {
                decimal Gtotal = 0;
                int invid = new Repo<string>().GetMaxId("SELECT ISNULL(MAX(Invid), 0) + 1 AS Invid FROM STOMaster");
                for (int i=0; i < Itemid.Count(); i++)
                {
                    _context.Database.ExecuteSqlRaw("INSERT INTO STODetail (Itemid, itemName, Qty, Price, Total, Invid, Vtype) VALUES " +
                        "('"+ Itemid[i] +"','"+ ItemName[i] +"','"+ Qty[i] +"','"+ Cp[i] +"','"+ Total[i] +"',"+ invid +",'STOINV') ");
                    Gtotal += Total[i]; 
                }
                _context.Database.ExecuteSqlRaw("INSERT INTO STOMaster(DateOrder, RequiredDate, DelieverPerson, Siteid, Invid, Vtype, GTotal,Status) VALUES " +
                    "('"+ STOMaster.DateOrder +"','"+ STOMaster.RequiredDate +"','"+ STOMaster.DelieverPerson +"','"+ STOMaster.Siteid +"','"+ invid +"','STOINV',"+ Gtotal +",'Pending') ");
                dir = "Create";
                TempData["Insert"] = "Inserted Successfully.";
            }
            else
            {
                _context.Database.ExecuteSqlRaw("DELETE FROM STODetail WHERE (Invid = "+ STOMaster.Invid +")");
                decimal Gtotal = 0;
                //int invid = new Repo<string>().GetMaxId("SELECT ISNULL(MAX(Invid), 0) + 1 AS Invid FROM STOMaster");
                for (int i = 0; i < Itemid.Count(); i++)
                {
                    _context.Database.ExecuteSqlRaw("INSERT INTO STODetail (Itemid, itemName, Qty, Price, Total, Invid, Vtype) VALUES " +
                        "('" + Itemid[i] + "','" + ItemName[i] + "','" + Qty[i] + "','" + Cp[i] + "','" + Total[i] + "'," + STOMaster.Invid + ",'STOINV') ");
                    Gtotal += Total[i];
                }
                _context.Database.ExecuteSqlRaw("UPDATE STOMaster SET DateOrder ='"+ STOMaster.DateOrder +"', RequiredDate ='"+ STOMaster.RequiredDate +"', DelieverPerson ="+ STOMaster.DelieverPerson +", Siteid ="+ STOMaster.Siteid +", GTotal ="+ Gtotal + " WHERE (Invid = "+ STOMaster.Invid +")");
                dir = "Index";
                TempData["update"] = "Updated Successfully.";
            }
            return RedirectToAction(dir);
        }
        public IActionResult Edit(int id)
        {
            var dbSTOMaster = _context.STOMaster.SingleOrDefault(c=> c.Invid == id);
            var ProductList = _context.Product.ToList();
            var SiteList = _context.Site.ToList();
            var EmployeeList = _context.DEmployee.ToList();
            var STODetail = _context.STODetail.FromSqlRaw("SELECT * FROM STODetail WHERE(Invid = "+ id +")").ToList();
            var ViewModel = new STOVM
            {
                STOMaster = dbSTOMaster,
                ProductList = ProductList,
                SiteList = SiteList,
                EmployeeList = EmployeeList,
                STODetailList = STODetail,
            };
            return View("Create",ViewModel);
        }
    }
}
