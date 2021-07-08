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
        public List<DEmployee> ManagerList { get; set; }
        public List<DEmployee> EmployeeList { get; set; }
        public List<ResultVMQ> ResultVMQList { get; set; }
        public List<ResultManagerFirstVMQ> ResultManagerFirstVMQList { get; set; }
        public List<ResultManagerSecondVMQ> ResultManagerSecondVMQList { get; set; }
        public string Stdate { get; set; }
        public string Endate { get; set; }
        public string EmpName { get; set; }
        public int E { get; set; }
        public int Eid { get; set; }
    }
}
