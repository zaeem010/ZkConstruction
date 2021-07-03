using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.Data;
using ZkConstruction.Data.Repository;
using ZkConstruction.ViewModel;
using ZkConstruction.ViewModelQuery;

namespace ZkConstruction.Controllers
{
    public class WorkProcessController : Controller
    {
        private readonly ApplicationDbContext _context;
        public WorkProcessController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(new Repo<DailysheduleVMQ>().GetAllData("SELECT DailyShedule.id, DailyShedule.Date, DailyShedule.Sheduleid, EProject.Name AS ProjectName, Site.Name AS SiteName FROM DailyShedule INNER JOIN EProject ON DailyShedule.Projectid = EProject.Proid INNER JOIN Site ON DailyShedule.Siteid = Site.id"));
        }
        public IActionResult Report(int id)
        {
            var Report = new Repo<WorkProcessDetailVMQ>().GetAllData("SELECT DailyShedule.Date, DailyShedule.Sheduleid, EProject.Name AS ProjectName, Site.Name AS SiteName FROM DailyShedule INNER JOIN EProject ON DailyShedule.Projectid = EProject.Proid INNER JOIN Site ON DailyShedule.Siteid = Site.id WHERE(DailyShedule.Sheduleid = "+ id +")").SingleOrDefault(); ;
            var List = new Repo<WorkProcessListVMQ>().GetAllData("SELECT DailySheduleChild.Employeeid,DailySheduleChild.Status, DailySheduleChild.Sheduleid, Section.Name AS SectionName, SubSection.Name AS SubSectionName, DEmployee.Name AS EmployeeName FROM DailySheduleChild INNER JOIN Section ON DailySheduleChild.Sectionid = Section.id INNER JOIN SubSection ON DailySheduleChild.Subsectionid = SubSection.id INNER JOIN DEmployee ON DailySheduleChild.Employeeid = DEmployee.AccountNo WHERE(DailySheduleChild.Sheduleid = " + id +")").ToList();
            var VM = new WorkProcessVM 
            {
            WorkProcessDetailVMQ=Report,
            WorkProcessListVMQ=List,
            };
            return View(VM);
        }
        [HttpPost]
        public IActionResult Save(int Sheduleid,string [] Status ,int[] Empid)
        {
            for (int i=0; i < Empid.Count(); i++)
            {
                _context.Database.ExecuteSqlRaw("UPDATE DailySheduleChild SET Status ='"+ Status[i] +"' WHERE (Sheduleid = "+ Sheduleid + ") AND (Employeeid = "+ Empid[i] +")");
            }
            return RedirectToAction("Index");
        }
    }
}
