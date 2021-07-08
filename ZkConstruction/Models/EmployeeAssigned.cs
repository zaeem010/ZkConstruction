using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZkConstruction.Models
{
    public class EmployeeAssigned
    {
        public int id { get; set; }
        public int Proid { get; set; }
        public int Siteid { get; set; }
        public int Employeeid { get; set; }
        public string Type { get; set; }
        public string CloseDateTime { get; set; }
        public string StartDateTime { get; set; }
    }
}
