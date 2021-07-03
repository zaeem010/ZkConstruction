using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.Models;
using ZkConstruction.ViewModelQuery;

namespace ZkConstruction.ViewModel
{
    public class STDReportVM
    {
        public STDMasterRepoVMQ STDMasterRepoVMQ { get; set; }
        public List<STDDetail> STDDetailLList { get; set; }
    }
}
