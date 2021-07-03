using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZkConstruction.Models
{
    public class DEmployee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public double AccountNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string Designation { get; set; }
        public string DOB { get; set; }
        public string DOJ { get; set; }
        public string PerHourSalary { get; set; }
        public string Image { get; set; }
        public string StTime { get; set; }
        public string EnTime { get; set; }
    }
    public class Designation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Name { get; set; }
    }
}
