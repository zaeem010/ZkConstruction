using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZkConstruction.Models
{
    public class EmpassignClose
    {
        [Key]
        public int id { get; set; }
        public int Proid { get; set; }
        public int Employeeid { get; set; }
        public string Type { get; set; }
        public string CloseDateTime { get; set; }
    }
}
