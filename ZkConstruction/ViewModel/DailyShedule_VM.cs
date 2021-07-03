using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.Models;
using ZkConstruction.ViewModelQuery;

namespace ZkConstruction.ViewModel
{
    public class DailyShedule_VM
    {
        public DailyShedule DailyShedule { get; set; }
        public List<EProject> ProjectList { get; set; }
        public List<EProjectchild> ProjectchildList { get; set; }
        public List<Section> SectionList { get; set; }
        public List<Subsection> SubsectionList { get; set; }
        public List<DEmployee> EmployeeList { get; set; }
        public List<Site> SiteList { get; set; }
        public List<DailyChildVMQ> DailysheduleVMQList { get; set; }
    }
}
