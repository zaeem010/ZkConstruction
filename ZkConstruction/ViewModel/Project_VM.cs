using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.Models;
using ZkConstruction.ViewModelQuery;

namespace ZkConstruction.ViewModel
{
    public class Project_VM
    {
        public Site Site { get; set; }
        public EProject EProject { get; set; }
        public EProjectchild EProjectchild  { get; set; }
        public List<EProjectchild> EProjectchildList  { get; set; }
        public List<DEmployee> MangerList { get; set; }
        public List<DEmployee> SupervisorList { get; set; }
        public List<Site> SiteList { get; set; }
        public List<Section> SectionList { get; set; }
        public List<Company> CompanyList { get; set; }
        public List<Customer> CustomerList { get; set; }
    }
}
