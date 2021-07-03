using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZkConstruction.Models
{
    public class Section
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
    }
}
