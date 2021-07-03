using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZkConstruction.Models
{
    public class Assignchild
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int Assignid { get; set; }
        public int EmployeeAcc { get; set; }
        public string Designation { get; set; }
    }
}
