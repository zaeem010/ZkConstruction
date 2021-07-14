using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZkConstruction.Models
{
    public class Documents
    {
        [Key]
        public int id { get; set; }
        public int Proid { get; set; }
        public string Img { get; set; }
        public string Type { get; set; }
    }
}
