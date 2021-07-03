using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZkConstruction.Models
{
    public class EmployeeAttendance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int EmpCode { get; set; }
        public string Status { get; set; }
        public DateTime CheckInOut { get; set; }
        public string Reamark { get; set; }
    }
}
