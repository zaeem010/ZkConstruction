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
    public class ManagementController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ManagementController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            var Detail = new Repo<Gantt_VMQ>().GetAllData("SELECT EProject.Name, EProject.StDate, EProject.HandDate, EProject.Proid, DEmployee.Name AS Supervisor, DEmployee_1.Name AS Manager, Site.Name AS Site, EProject.Status FROM EProject INNER JOIN DEmployee ON EProject.SuperVisor = DEmployee.id INNER JOIN DEmployee AS DEmployee_1 ON EProject.Manager = DEmployee_1.id INNER JOIN Site ON EProject.site = Site.id WHERE(EProject.Proid = "+ id +")").SingleOrDefault();
            var list = new Repo<Gantt_VMQList>().GetAllData("SELECT ProjectAssign.Projectid, ProjectAssign.StDate, ProjectAssign.EnDate, SubSection.Name FROM ProjectAssign INNER JOIN SubSection ON ProjectAssign.SubSecid = SubSection.id WHERE(ProjectAssign.Projectid = "+ id +")").ToList();
            var viewmodel = new Gantt_VM
            {
                GanttVMQ=Detail,
                Gantt_VMQLists=list,
            };
            return View(viewmodel);
        }
        public IActionResult Report(int Siteid ,int Proid)
        {
            List<ProjectReport2ListVMQ> ProjectReport2ListVMQ = new List<ProjectReport2ListVMQ>();
            List<Models.DailyShedule> DailyShedule = new List<Models.DailyShedule>();
            List<Models.SitevisitImage> SiteImages = new List<Models.SitevisitImage>();
            int c1, c2, c3 = 0;
            var ProjectReport1VMQ = new Repo<ProjectReport1VMQ>().GetAllData("SELECT EProject.Name, EProject.StDate, EProject.HandDate, EProject.Status, Site.Name AS SiteName, DEmployee.Name AS SupervisorName, DEmployee_1.Name AS ManagerName, EProject.Proid FROM EProject INNER JOIN Site ON EProject.site = Site.id INNER JOIN DEmployee ON EProject.SuperVisor = DEmployee.id INNER JOIN DEmployee AS DEmployee_1 ON EProject.Manager = DEmployee_1.id WHERE(EProject.Proid = "+ Proid +") AND (EProject.site = "+ Siteid +")").SingleOrDefault();
            var ProjectReport2VMQ = new Repo<ProjectReport2VMQ>().GetAllData("SELECT ProjectAssign.StDate, ProjectAssign.EnDate, ProjectAssign.Assignid, EProject.Name AS ProjectName, Section.Name AS SecName, ProjectAssign.Projectid, SubSection.Name AS SubName FROM ProjectAssign INNER JOIN EProject ON ProjectAssign.Projectid = EProject.Proid INNER JOIN Section ON ProjectAssign.Secid = Section.id INNER JOIN SubSection ON ProjectAssign.SubSecid = SubSection.id WHERE(ProjectAssign.Projectid = "+ Proid +")").SingleOrDefault();
           
            c1 = new Repo<string>().GetMaxId("SELECT count(*) FROM ProjectAssign INNER JOIN EProject ON ProjectAssign.Projectid = EProject.Proid INNER JOIN Section ON ProjectAssign.Secid = Section.id INNER JOIN SubSection ON ProjectAssign.SubSecid = SubSection.id WHERE(ProjectAssign.Projectid = "+ Proid +")");
            if (c1 != 0)
            {
                 ProjectReport2ListVMQ = new Repo<ProjectReport2ListVMQ>().GetAllData("SELECT Assignchild.Assignid, DEmployee.Name AS EmployeeName, Designation.Name AS DesignationName FROM Assignchild INNER JOIN DEmployee ON Assignchild.EmployeeAcc = DEmployee.AccountNo INNER JOIN Designation ON DEmployee.Designation = Designation.id WHERE(Assignchild.Assignid = " + ProjectReport2VMQ.Assignid + ")").ToList();
            }
            else 
            {
                 ProjectReport2ListVMQ = new Repo<ProjectReport2ListVMQ>().GetAllData("SELECT Assignchild.Assignid, DEmployee.Name AS EmployeeName, Designation.Name AS DesignationName FROM Assignchild INNER JOIN DEmployee ON Assignchild.EmployeeAcc = DEmployee.AccountNo INNER JOIN Designation ON DEmployee.Designation = Designation.id WHERE(Assignchild.Assignid = 0)").ToList();
            }

            c2 = new Repo<string>().GetMaxId("SELECT count(*) FROM DailyShedule WHERE(Projectid = " + Proid + ") AND (Siteid = " + Siteid + ")");
            if (c2 != 0)
            {
                 DailyShedule = _context.DailyShedule.FromSqlRaw("SELECT * FROM DailyShedule WHERE(Projectid = " + Proid + ") AND (Siteid = " + Siteid + ")").ToList();
            }
            else
            {
                 DailyShedule = _context.DailyShedule.FromSqlRaw("SELECT * FROM DailyShedule WHERE(Projectid = 0) AND (Siteid = 0)").ToList();
            }
            var DailySheduleChildVMQList = new Repo<DailySheduleChildVMQ>().GetAllData("SELECT DailySheduleChild.Sheduleid, DailySheduleChild.Status, DEmployee.Name AS EmployeeName, Section.Name AS SectionName, SubSection.Name AS SubName FROM DailySheduleChild INNER JOIN DEmployee ON DailySheduleChild.Employeeid = DEmployee.AccountNo INNER JOIN Section ON DailySheduleChild.Sectionid = Section.id INNER JOIN SubSection ON DailySheduleChild.Subsectionid = SubSection.id").ToList();
            
            var SiteVisit1VMQ = new Repo<SiteVisit1VMQ>().GetAllData("SELECT Sitevisit.Projectid, Sitevisit.Siteid, Sitevisit.Visitid, Sitevisit.Date, Sitevisit.Area, DEmployee.Name AS EmployeeName FROM Sitevisit INNER JOIN DEmployee ON Sitevisit.Surveyor = DEmployee.AccountNo WHERE(Sitevisit.Projectid = "+ Proid +") AND (Sitevisit.Siteid = "+ Siteid +")").SingleOrDefault();

            c3 = new Repo<string>().GetMaxId("SELECT Count(*) FROM Sitevisit INNER JOIN DEmployee ON Sitevisit.Surveyor = DEmployee.AccountNo WHERE(Sitevisit.Projectid = " + Proid + ") AND (Sitevisit.Siteid = " + Siteid + ")");
            if (c3 != 0)
            {
                 SiteImages = _context.SitevisitImage.FromSqlRaw("SELECT * FROM SitevisitImage WHERE (Visitid =" + SiteVisit1VMQ.Visitid + ")").ToList();
            }
            else 
            {
                SiteImages = _context.SitevisitImage.FromSqlRaw("SELECT * FROM SitevisitImage WHERE (Visitid = 0)").ToList();
            }
            
            var VM = new ProjectReportVM
            {
                ProjectReport1VMQ= ProjectReport1VMQ,
                ProjectReport2VMQ= ProjectReport2VMQ,
                ProjectReport2ListVMQ=ProjectReport2ListVMQ,
                DailyShedule1List=DailyShedule,
                DailySheduleChildVMQList = DailySheduleChildVMQList,
                SiteVisit1VMQ= SiteVisit1VMQ,
                SitevisitImage= SiteImages,
            };
            return View(VM);
        }
    }
}
