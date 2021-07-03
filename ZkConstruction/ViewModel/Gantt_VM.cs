using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.ViewModelQuery;

namespace ZkConstruction.ViewModel
{
    public class Gantt_VM
    {
        public Gantt_VMQ GanttVMQ { get; set; }
        public List<Gantt_VMQList> Gantt_VMQLists { get; set; }
    }
}
