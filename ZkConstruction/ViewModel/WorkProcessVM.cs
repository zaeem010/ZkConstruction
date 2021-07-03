using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.ViewModelQuery;

namespace ZkConstruction.ViewModel
{
    public class WorkProcessVM
    {
        public WorkProcessDetailVMQ WorkProcessDetailVMQ { get; set; }
        public List<WorkProcessListVMQ> WorkProcessListVMQ { get; set; }
    }
}
