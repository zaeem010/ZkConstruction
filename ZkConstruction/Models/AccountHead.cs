using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZkConstruction.Models
{
    public class AccountHead
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }
        public string HeadName { get; set; }
    }
    public class FirstLevel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }
        public double AccountNo { get; set; }
        public double Headid { get; set; }
        public double Comid { get; set; }
        public string AccountTitle { get; set; }
    }
    public class SecondLevel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }
        public double Headid { get; set; }
        public double SubHeadid { get; set; }
        public double AccountNo { get; set; }
        public double Comid { get; set; }
        public string AccountTitle { get; set; }
    }
    public class ThirdLevel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }
        public double AccountNo { get; set; }
        public double Headid { get; set; }
        public double SubHeadid { get; set; }
        public double SecondHeadid { get; set; }
        public string AccountTitle { get; set; }
        public string AccountType { get; set; }
        public double Dr { get; set; }
        public double Cr { get; set; }
        public double Comid { get; set; }
    }
    public class City
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }
        public string Name { get; set; }
    }
}
