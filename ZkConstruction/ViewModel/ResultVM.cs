using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.Models;

namespace ZkConstruction.ViewModel
{
    public class ResultVM
    {
        public List<DEmployee> EmployeeList { get; set; }
        public string Stdate { get; set; }
        public string Endate { get; set; }
    }
}
