using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace ZkConstruction.Models
{
    public class ProjectAssign
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int Projectid { get; set; }
        public int Assignid { get; set; }
        public string Secid { get; set; }
        public string SubSecid { get; set; }
        public string StDate { get; set; }
        public string EnDate { get; set; }
    }
}
