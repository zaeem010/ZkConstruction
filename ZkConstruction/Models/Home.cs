using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZkConstruction.Models
{
    public class Home
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string StDate { get; set; }
        public string HandDate { get; set; }
        public string Status { get; set; }
        public string Floor { get; set; }
        public string Electricity { get; set; }
        public int Manager { get; set; }
        public int site { get; set; }
        public int Proid { get; set; }
        public int Comid { get; set; }
        public int Customerid { get; set; }
        public string Sr { get; set; }
        public string WorkHours { get; set; }
        public string FlooringRoom { get; set; }
        public int PaintingHours { get; set; }
        public int FlooringHours { get; set; }
        public int RemainingHours { get; set; }
        public string StTime { get; set; }
    }
}
