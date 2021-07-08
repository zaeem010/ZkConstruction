using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.Models;
using ZkConstruction.ViewModelQuery;

namespace ZkConstruction.ViewModel
{
    public class ResultVM
    {
        public List<DEmployee> EmployeeList { get; set; }
        public List<ResultVMQ> ResultVMQList { get; set; }
        public string Stdate { get; set; }
        public string Endate { get; set; }
        public int E { get; set; }
        public int Eid { get; set; }
    }
}
