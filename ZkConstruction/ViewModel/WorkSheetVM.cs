using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.Models;

namespace ZkConstruction.ViewModel
{
    public class WorkSheetVM
    {
        public Worksheet WorkSheet { get; set; }
        public List<EProject> ProjectList { get; set; }
        public List<Site> SiteList { get; set; }
    }
}
