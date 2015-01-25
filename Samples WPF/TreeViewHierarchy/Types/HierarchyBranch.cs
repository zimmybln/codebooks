using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewHierarchy.Types
{
    public class HierarchyBranch
    {
        internal HierarchyBranch()
        {
            Branches = new List<HierarchyBranch>();
        }

        public List<HierarchyBranch> Branches { get; private set; }
        
        public string Name { get; set; }
    }
}
