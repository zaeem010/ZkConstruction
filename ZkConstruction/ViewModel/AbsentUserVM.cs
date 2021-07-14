using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.Models;

namespace ZkConstruction.ViewModel
{
    public class AbsentUserVM
    {
        public AbsentUser AbsentUser { get; set; }
        public List<EProject> ProjectList { get; set; }
        public List<DEmployee> EmployeeList { get; set; }
    }
}
