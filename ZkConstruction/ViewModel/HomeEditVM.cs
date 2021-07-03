using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.Models;
using ZkConstruction.ViewModelQuery;

namespace ZkConstruction.ViewModel
{
    public class HomeEditVM
    {
        public List<ManageVMQ> ManageVMQList { get; set; }
        public List<Company> CompanyList { get; set; }
        public List<Site> SiteList { get; set; }
        public List<Customer> CustomerList { get; set; }
        public List<DEmployee> EmployeeList { get; set; }
        public List<DEmployee> ManagerList { get; set; }
        public List<EmployeeAssigned> EmployeeAssignedPaintList { get; set; }
        public List<EmployeeAssigned> EmployeeAssignedFloorList { get; set; }
    }
}
