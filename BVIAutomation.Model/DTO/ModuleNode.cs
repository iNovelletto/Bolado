using BVIAutomation.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVIAutomation.Model.DTO
{
    public class ModuleNode
    {
        public List<ModuleNode> Children = new List<ModuleNode>();
        public ModuleNode Parent { get; set; }
        public Module Source { get; set; }
    }
}
