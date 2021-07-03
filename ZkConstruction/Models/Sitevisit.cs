using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZkConstruction.Models
{
    public class Sitevisit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int Projectid { get; set; }
        public int Siteid { get; set; }
        public int Surveyor { get; set; }
        public int Visitid { get; set; }
        public string Date { get; set; }
        public string Area { get; set; }
    }
    public class SitevisitImage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int Visitid { get; set; }
        public string Image { get; set; }
    }
}
