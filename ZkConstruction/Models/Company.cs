using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZkConstruction.Models
{
    public class Company
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
    }
}
