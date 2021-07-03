using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.Models;
using ZkConstruction.ViewModelQuery;

namespace ZkConstruction.ViewModel
{
    public class ProjectReportVM
    {
        public ProjectReport1VMQ ProjectReport1VMQ { get; set; }
        public ProjectReport2VMQ ProjectReport2VMQ { get; set; }
        public SiteVisit1VMQ SiteVisit1VMQ { get; set; }
        public List<ProjectReport2ListVMQ> ProjectReport2ListVMQ { get; set; }
        public List<DailyShedule> DailyShedule1List { get; set; }
        public List<DailySheduleChildVMQ> DailySheduleChildVMQList { get; set; }
        public List<SitevisitImage> SitevisitImage { get; set; }
    }
}
