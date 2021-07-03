using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.Models;

namespace ZkConstruction.ViewModel
{
    public class STOVM
    {
        public List<Site> SiteList { get; set; }
        public List<Product> ProductList { get; set; }
        public List<DEmployee> EmployeeList { get; set; }
        public List<STODetail> STODetailList { get; set; }
        public STOMaster STOMaster { get; set; }
    }
}
