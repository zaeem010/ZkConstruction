using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZkConstruction.Models
{
    public class STDMaster
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string DateDelivery { get; set; }
        public int ReciverPerson { get; set; }
        public int Siteid { get; set; }
        public int Invid { get; set; }
        public string Vtype { get; set; }
        public decimal GTotal { get; set; }
    }
    public class STDDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int Itemid { get; set; }
        public string itemName { get; set; }
        public int Qty { get; set; }
        public int QtyDelievered { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public int Invid { get; set; }
        public string Vtype { get; set; }
    }
}
