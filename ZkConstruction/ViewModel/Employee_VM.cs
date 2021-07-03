using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.Models;

namespace ZkConstruction.ViewModel
{
    public class Employee_VM
    {
        public List<City> Cities { get; set; }
        public List<Designation> Designationlist { get; set; }
        public DEmployee DEmployee { get; set; }
    }
}
