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
    public class StockDelieveryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StockDelieveryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var List = new Repo<STDMasterVMQ>().GetAllData("SELECT DateDelivery, Invid, GTotal,DEmployee.Name As EmployeeName,Site.Name As SiteName FROM STDMaster  inner join DEmployee on STDMaster.ReciverPerson=DEmployee.AccountNo inner join Site on STDMaster.Siteid=Site.id").ToList();
            return View(List);
        }
        public IActionResult Create(int id,STDMaster STDMaster)
        {
            var SiteList = _context.Site.ToList();
            var EmployeeList = _context.DEmployee.ToList();
            var ProductList = _context.STODetail.FromSqlRaw("SELECT * FROM STODetail WHERE (Invid = "+ id +")").ToList();
            var Siteid = new Repo<string>().GetMaxId("SELECT Siteid FROM STOMaster WHERE(Invid = "+ id +")");
            STDMaster.Siteid = Siteid;
            var VM = new STDVM
            {
                STDMaster = STDMaster,
                SiteList=SiteList,
                EmployeeList=EmployeeList,
                STODetailList=ProductList,
                Invid = id,
            };
            return View(VM);
        }
        [HttpPost]
        public IActionResult Save(STDMaster STDMaster, string[] ItemName, int[] Qty, int[] QtyDeliever ,decimal[] Cp ,decimal[] Total ,int[] Itemid,int id)
        {
            decimal Gtotal = 0;
            int invid = new Repo<string>().GetMaxId("SELECT ISNULL(MAX(Invid), 0) + 1 AS Invid FROM STDMaster");
            for (int i = 0; i < Itemid.Count(); i++)
            {
                _context.Database.ExecuteSqlRaw("INSERT INTO STDDetail (Itemid, itemName, Qty, Price, Total, Invid, Vtype,QtyDelievered) VALUES " +
                    "('" + Itemid[i] + "','" + ItemName[i] + "','" + Qty[i] + "','" + Cp[i] + "','" + Total[i] + "'," + invid + ",'STDINV','"+ QtyDeliever[i] +"')");
                Gtotal += Total[i];
            }
            _context.Database.ExecuteSqlRaw("INSERT INTO STDMaster (DateDelivery, ReciverPerson, Siteid, Invid, Vtype, GTotal) VALUES " +
            "('" + STDMaster.DateDelivery + "','" + STDMaster.ReciverPerson + "','" + STDMaster.Siteid + "','" + invid + "','STDINV'," + Gtotal + ") ");
            _context.Database.ExecuteSqlRaw("UPDATE STOMaster SET Status ='Cleared' WHERE (Invid = "+ id +")");
            TempData["Insert"] = "Inserted Successfully.";
            return RedirectToAction("Index");
        }
        public IActionResult Report(int id)
        {
            var Repo = new Repo<STDMasterRepoVMQ>().GetAllData("SELECT STDMaster.DateDelivery, STDMaster.Invid, DEmployee.Name AS ReciverPerson, Site.Name AS SiteName FROM STDMaster INNER JOIN DEmployee ON STDMaster.ReciverPerson = DEmployee.AccountNo INNER JOIN Site ON STDMaster.Siteid = Site.id WHERE(STDMaster.Invid = "+ id +")").SingleOrDefault();
            var Detail = _context.STDDetail.FromSqlRaw("SELECT * FROM  STDDetail WHERE (Invid = "+ id +")").ToList();
            var VM = new STDReportVM
            {
                STDMasterRepoVMQ=Repo,
                STDDetailLList=Detail,
            };
            return View(VM);
        }
    }
}
