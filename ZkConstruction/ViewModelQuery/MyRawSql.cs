using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZkConstruction.ViewModelQuery
{
    public class EmpFloorCheckedVMQ 
    {
        public int id { get; set; }
        public int Proid { get; set; }
        public int Employeeid { get; set; }
        public string Type { get; set; }
        public string EmpName { get; set; }
        public string CloseDateTime { get; set; }
    }
    public class ManageVMQ
    {
        public string ManagerName { get; set; }
        public string PaEmNames { get; set; }
        public string FlEmNames { get; set; }
        public string CompanyName { get; set; }
        public string SiteName { get; set; }
        public string Floor { get; set; }
        public string CustomerName { get; set; }
        public string HandDate { get; set; }
        public string Name { get; set; }
        public string Electricity { get; set; }
        public string StDate { get; set; }
        public string Fl { get; set; }
        public string Pa { get; set; }
        public string Wa { get; set; }
        public string Cl { get; set; }
        public string Sr { get; set; }
        public string WorkHours { get; set; }
        public string StTime { get; set; }
        public int FlooringHours { get; set; }
        public int PaintingHours { get; set; }
        public int RemainingHours { get; set; }
        public int Proid { get; set; }
        public int PaEm { get; set; }
        public int FlEm { get; set; }
        public int Manager { get; set; }
        public string FlooringRoom { get; set; }
        public string StdateTimeFlooring { get; set; }
    }
    public class SiteVisit1VMQ
    {
        public int Projectid { get; set; }
        public int Siteid { get; set; }
        public int Visitid { get; set; }
        public string Date { get; set; }
        public string Area { get; set; }
        public string EmployeeName { get; set; }
    }
    public class DailySheduleChildVMQ 
    {
        public int Sheduleid { get; set; }
        public string Status { get; set; }
        public string EmployeeName { get; set; }
        public string SectionName { get; set; }
        public string SubName { get; set; }
    }
    public class ProjectReport2ListVMQ
    {
        public int Assignid { get; set; }
        public string EmployeeName { get; set; }
        public string DesignationName { get; set; }
    }
    public class ProjectReport2VMQ
    {
        public int Assignid { get; set; }
        public int Projectid { get; set; }
        public string StDate { get; set; }
        public string EnDate { get; set; }
        public string ProjectName { get; set; }
        public string SecName { get; set; }
        public string SubName { get; set; }
    }
    public class ProjectReport1VMQ
    {
        public string Name { get; set; }
        public string StDate { get; set; }
        public string HandDate { get; set; }
        public string Status { get; set; }
        public string SiteName { get; set; }
        public string SupervisorName { get; set; }
        public string ManagerName { get; set; }
        public int Proid { get; set; }
    }
    public class WorksheetVMQ
    {
        public int id { get; set; }
        public string Date { get; set; }
        public string CompanyName { get; set; }
        public string SiteAddress { get; set; }
        public string AccoummodationNo { get; set; }
        public string ProviderOrderNo { get; set; }
        public string FloorSide { get; set; }
        public string SiteName { get; set; }
        public string ProjectName { get; set; }
    }
    public class WorkProcessListVMQ
    {
        public int Sheduleid { get; set; }
        public string SectionName { get; set; }
        public string SubSectionName { get; set; }
        public string EmployeeName { get; set; }
        public string Status { get; set; }
        public int Employeeid { get; set; }
    }
    public class WorkProcessDetailVMQ 
    {
        public int Sheduleid { get; set; }
        public string Date { get; set; }
        public string SiteName { get; set; }
        public string ProjectName { get; set; }
    }
    public class STDMasterRepoVMQ
    {
        public int Invid { get; set; }
        public string ReciverPerson { get; set; }
        public string DateDelivery { get; set; }
        public string SiteName { get; set; }
    }
    public class STDMasterVMQ
    {
        public int Invid { get; set; }
        public string DateDelivery { get; set; }
        public string EmployeeName { get; set; }
        public string SiteName { get; set; }
        public decimal GTotal { get; set; }
    }
    public class AttendanceVMQ
    {
        public int EmpCode { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public DateTime CheckInOut { get; set; }
    }
    public class STOVMQ
    {
        public int Invid { get; set; }
        public string DateOrder { get; set; }
        public string RequiredDate { get; set; }
        public string Name { get; set; }
        public string SiteName { get; set; }
        public string Status { get; set; }
    }
    public class Gantt_VMQ
    {
        public string Name { get; set; }
        public string StDate { get; set; }
        public string HandDate { get; set; }
        public string Supervisor { get; set; }
        public string Manager { get; set; }
        public string Site { get; set; }
        public string Status { get; set; }
        public int Proid { get; set; }
    }
    public class Gantt_VMQList 
    {
        public int Projectid { get; set; }
        public string StDate { get; set; }
        public string EnDate { get; set; }
        public string Name { get; set; }
    }
    public class ProjectVMQS
    {
        public int Proid { get; set; }
        public int Siteid { get; set; }
        public string Name { get; set; }
        public string StDate { get; set; }
        public string HandDate { get; set; }
        public string Site { get; set; }
        public string Status { get; set; }
    }
    public class ProjectAssignVMQ
    {
        public int id { get; set; }
        public int Assignid { get; set; }
        public string StDate { get; set; }
        public string EnDate { get; set; }
        public string ProjectName { get; set; }
        public string SecName { get; set; }
    }
    public class subsecVMQ
    {
        public int id { get; set; }
        public string SectionName { get; set; }
        public string Name { get; set; }
    }
    public class SiteVisitVMQ
    {
        public int Visitid { get; set; }
        public string Date { get; set; }
        public string ProjectName { get; set; }
        public string Surveyor { get; set; }
        public string SiteName { get; set; }
    }
    public class DailysheduleVMQ
    {
        public int id { get; set; }
        public int Sheduleid { get; set; }
        public string Date { get; set; }
        public string ProjectName { get; set; }
        public string SiteName { get; set; }
    }
    public class DailyChildVMQ
    {
        public int id { get; set; }
        public int Sheduleid { get; set; }
        public int Sectionid { get; set; }
        public int Subsectionid { get; set; }
        public int Employeeid { get; set; }
        public string SectionName { get; set; }
        public string SubsectionName { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
    }
    public class strings
    {
        public string Strings { get; set; }
    }
}
