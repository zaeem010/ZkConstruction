using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZkConstruction.Models
{
    public class EProject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }
        public string Name { get; set; }
        public string StDate { get; set; }
        public string HandDate { get; set; }
        public string Status { get; set; }
        public string Floor { get; set; }
        public string Electricity { get; set; }
        //public int SuperVisor { get; set; }
        public int Manager { get; set; }
        public int site { get; set; }
        public int Proid { get; set; }
        public int Comid { get; set; }
        public int Customerid { get; set; }
        public string Sr { get; set; }
        public string WorkHours { get; set; }
    }
}
