using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZkConstruction.Models
{
    public class DailyShedule
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int Projectid { get; set; }
        public int Siteid { get; set; }
        public int Sheduleid { get; set; }
        public string Date { get; set; }
    }
    public class DailySheduleChild
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int Sheduleid { get; set; }
        public int Sectionid { get; set; }
        public int Subsectionid { get; set; }
        public int Employeeid { get; set; }
        public string Status { get; set; }
    }
}
