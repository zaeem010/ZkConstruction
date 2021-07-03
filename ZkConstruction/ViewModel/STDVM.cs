using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.Models;

namespace ZkConstruction.ViewModel
{
    public class STDVM
    {
        public STDDetail STDDetail { get; set; }
        public STDMaster STDMaster { get; set; }
        public List<STODetail> STODetailList { get; set; }
        public List<DEmployee> EmployeeList { get; set; }
        public List<Site> SiteList { get; set; }
        public int Invid { get; set; }
    }
}
