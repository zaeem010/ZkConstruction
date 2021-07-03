using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.Models;

namespace ZkConstruction.ViewModel
{
    public class SiteVisit_VM
    {
        public List<EProject> ProjectList { get; set; }
        public List<Site> SiteList { get; set; }
        public List<DEmployee> EmployeeList { get; set; }
        public Sitevisit Sitevisit { get; set; }
        public SitevisitImage SitevisitImage { get; set; }
    }
}
