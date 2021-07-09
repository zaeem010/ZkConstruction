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
    public class ResultController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ResultController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var ManagerList = _context.DEmployee.FromSqlRaw("SELECT * FROM DEmployee WHERE (Designation = 1)").ToList();
            var EmployeeList = _context.DEmployee.FromSqlRaw("SELECT * FROM DEmployee WHERE (Designation NOT IN (1))").ToList();
            var VM = new ResultVM
            {
                ManagerList = ManagerList,
                EmployeeList=EmployeeList,
            };
            return View(VM);
        }
        
        [HttpPost]
        public IActionResult Search(int Mangerid, string Stdate, string Endate,int Emp,int Empid)
        {
            string EmpName,StTimedb, EnTimedb, EmpStTime, EmpEnTime = "";
            int FinalEmpid = 0;
            if (Mangerid != 0)
            {
                FinalEmpid = Mangerid;
            }
            if (Empid != 0)
            {
                FinalEmpid = Empid;
            }
            int Manid = new Repo<string>().GetMaxId("SELECT id FROM DEmployee WHERE (AccountNo = " + FinalEmpid + ")");
            var Res = new Repo<ResultVMQ>().GetAllData("SELECT Site.Name AS SiteName, EmployeeAssigned.StartDateTime, EmployeeAssigned.CloseDateTime, EmployeeAssigned.Siteid FROM EmployeeAssigned INNER JOIN Site ON EmployeeAssigned.Siteid = Site.id WHERE(LEFT(EmployeeAssigned.CloseDateTime, 10) BETWEEN '"+ Stdate +"' AND '"+ Endate +"' OR LEFT(EmployeeAssigned.StartDateTime, 10) BETWEEN '"+ Stdate +"' AND '"+ Endate +"') AND (EmployeeAssigned.Employeeid = "+ FinalEmpid + ") AND (EmployeeAssigned.StartDateTime <> 'NULL')").ToList();
            var ResManagerFirst = new Repo<ResultManagerFirstVMQ>().GetAllData("SELECT Home.site, Site.Name AS SiteName FROM Home INNER JOIN Site ON Home.site = Site.id WHERE(Home.Manager = "+ Manid + ") GROUP BY Home.site, Site.Name").ToList();
            var ResManagerSecond = new Repo<ResultManagerSecondVMQ>().GetAllData("SELECT Home.site, EmployeeAssigned.StartDateTime, EmployeeAssigned.Employeeid, EmployeeAssigned.CloseDateTime, DEmployee.Name AS EmpName FROM Home INNER JOIN EmployeeAssigned ON Home.Proid = EmployeeAssigned.Proid INNER JOIN DEmployee ON EmployeeAssigned.Employeeid = DEmployee.AccountNo WHERE(Home.Manager = " + Manid + ") AND (EmployeeAssigned.StartDateTime <> 'NULL')").ToList();
            EmpName = new Repo<string>().Getstring("SELECT Name FROM DEmployee WHERE (AccountNo = " + FinalEmpid + ")");
            EmpStTime = new Repo<string>().Getstring("SELECT StTime FROM DEmployee WHERE (AccountNo = "+ FinalEmpid +")");
            EmpEnTime = new Repo<string>().Getstring("SELECT EnTime FROM DEmployee WHERE (AccountNo = "+ FinalEmpid +")");

            List<siteduration> _siteduration = new List<siteduration>();
            List<Empduration> _Empduration = new List<Empduration>();
            if (Empid !=0)
            {
                for (int i = 0; i < Res.Count(); i++)
                {
                    StTimedb = Res[i].StartDateTime;
                    if (Res[i].CloseDateTime != "")
                    {
                        EnTimedb = Res[i].CloseDateTime;
                    }
                    else
                    {
                        EnTimedb = DateTime.Now.ToString();
                    }
                    List<DateTime> li = new List<DateTime>();
                    DateTime StTimeMatch = Convert.ToDateTime("1900-01-01 00:00:00");
                    DateTime EnTimeMatch = Convert.ToDateTime("1900-01-01 00:00:00");
                    DateTime stdtcheck = Convert.ToDateTime(StTimedb);
                    DateTime stdt = Convert.ToDateTime(StTimedb);
                    DateTime endt = Convert.ToDateTime(EnTimedb);
                    double Min, TotalMins = 0;
                    while (stdt <= endt)
                    {
                        li.Add(stdt);
                        stdt = stdt.AddDays(1);
                    }
                    for (int j = 0; j < li.Count(); j++)
                    {
                        if (li[j].ToString("yyyy-MM-dd") == stdtcheck.ToString("yyyy-MM-dd"))
                        {
                            StTimeMatch = stdtcheck;
                        }
                        else
                        {
                            StTimeMatch = Convert.ToDateTime("" + li[j].ToString("yyyy-MM-dd") + " " + EmpStTime + "");
                        }
                        if (li[j].ToString("yyyy-MM-dd") == endt.ToString("yyyy-MM-dd"))
                        {
                            EnTimeMatch = endt;
                        }
                        else
                        {
                            EnTimeMatch = Convert.ToDateTime("" + li[j].ToString("yyyy-MM-dd") + " " + EmpEnTime + "");
                        }
                        Min = (EnTimeMatch - StTimeMatch).TotalMinutes;
                        TotalMins += Min;
                    }
                    TimeSpan spWorkMin = TimeSpan.FromMinutes(TotalMins);
                    string workHours = string.Format("{0} Hour:{1} Min", (int)spWorkMin.TotalHours, spWorkMin.Minutes);
                    _siteduration.Add(new siteduration { site = Res[i].Siteid, TotalMins = workHours });
                }
            }
            if (Mangerid != 0)
            {
                for (int i = 0; i < ResManagerSecond.Count(); i++)
                {
                    EmpStTime = new Repo<string>().Getstring("SELECT StTime FROM DEmployee WHERE (AccountNo = " + ResManagerSecond[i].Employeeid + ")");
                    EmpEnTime = new Repo<string>().Getstring("SELECT EnTime FROM DEmployee WHERE (AccountNo = " + ResManagerSecond[i].Employeeid + ")");
                    StTimedb = ResManagerSecond[i].StartDateTime;
                    if (ResManagerSecond[i].CloseDateTime != "")
                    {
                        EnTimedb = ResManagerSecond[i].CloseDateTime;
                    }
                    else
                    {
                        EnTimedb = DateTime.Now.ToString();
                    }
                    List<DateTime> li = new List<DateTime>();
                    DateTime StTimeMatch = Convert.ToDateTime("1900-01-01 00:00:00");
                    DateTime EnTimeMatch = Convert.ToDateTime("1900-01-01 00:00:00");
                    DateTime stdtcheck = Convert.ToDateTime(StTimedb);
                    DateTime stdt = Convert.ToDateTime(StTimedb);
                    DateTime endt = Convert.ToDateTime(EnTimedb);
                    double Min, TotalMins = 0;
                    while (stdt <= endt)
                    {
                        li.Add(stdt);
                        stdt = stdt.AddDays(1);
                    }
                    for (int j = 0; j < li.Count(); j++)
                    {
                        if (li[j].ToString("yyyy-MM-dd") == stdtcheck.ToString("yyyy-MM-dd"))
                        {
                            StTimeMatch = stdtcheck;
                        }
                        else
                        {
                            StTimeMatch = Convert.ToDateTime("" + li[j].ToString("yyyy-MM-dd") + " " + EmpStTime + "");
                        }
                        if (li[j].ToString("yyyy-MM-dd") == endt.ToString("yyyy-MM-dd"))
                        {
                            EnTimeMatch = endt;
                        }
                        else
                        {
                            EnTimeMatch = Convert.ToDateTime("" + li[j].ToString("yyyy-MM-dd") + " " + EmpEnTime + "");
                        }
                        Min = (EnTimeMatch - StTimeMatch).TotalMinutes;
                        TotalMins += Min;
                    }
                    TimeSpan spWorkMin = TimeSpan.FromMinutes(TotalMins);
                    string workHours = string.Format("{0} Hour:{1} Min", (int)spWorkMin.TotalHours, spWorkMin.Minutes);
                    _Empduration.Add(new Empduration { EmpAccount = ResManagerSecond[i].Employeeid, TotalMins = workHours });
                }
            }
          
            var VM = new ResultVM
            {
                Stdate = Stdate,
                Endate = Endate,
                ResultVMQList=Res,
                Eid=Empid,
                E=Emp,
                EmpName=EmpName,
                ResultManagerFirstVMQList = ResManagerFirst,
                ResultManagerSecondVMQList=ResManagerSecond,
                sitedurationList=_siteduration,
                EmpdurationList=_Empduration,
            };
            return View(VM);
        }
        [HttpPost]
        public IActionResult Create(int Emp, string Stdate, string Endate)
        {
            List<DEmployee> EmployeeList = new List<DEmployee>();
            if (Emp == 1)
            {
                EmployeeList = _context.DEmployee.FromSqlRaw("SELECT * FROM DEmployee WHERE (Designation = 1)").ToList();
            }
            else
            {
                EmployeeList = _context.DEmployee.FromSqlRaw("SELECT * FROM DEmployee WHERE (Designation NOT IN (1))").ToList();
            }
            var VM = new ResultVM
            {
                EmployeeList = EmployeeList,
                Stdate = Stdate,
                Endate = Endate,
                E = Emp,
            };
            return View(VM);
        }
    }
}
