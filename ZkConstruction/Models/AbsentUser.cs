using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZkConstruction.Models
{
    public class AbsentUser
    {
        [Key]
        public int id { get; set; }
        public int Employeeid { get; set; }
        public int Proid { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
