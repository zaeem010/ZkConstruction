using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.Models;

namespace ZkConstruction.ViewModel
{
    public class AttendanceVM
    {
        public EmployeeAttendance EmployeeAttendance { get; set; }
        public List<DEmployee> EmployeeList { get; set; }
    }
}
