using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZkConstruction.Models
{
    public class Site
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        [DataType("decimal(18,0)")]
        public decimal id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
    }
}
