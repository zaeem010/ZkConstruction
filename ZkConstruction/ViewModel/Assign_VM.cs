using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZkConstruction.Models;

namespace ZkConstruction.ViewModel
{
    public class Assign_VM
    {
        public ProjectAssign projectAssign { get; set; }
        public List<EProject> ProjectList { get; set; }
        public List<Assignchild> AssignchildList { get; set; }
        public List<EProjectchild> ProjectchildList { get; set; }
        public List<Section> SectionList { get; set; }
        public List<Subsection>  SubsectionList { get; set; }
        public List<DEmployee> EmployeeList { get; set; }
    }
}
