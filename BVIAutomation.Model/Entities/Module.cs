using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVIAutomation.Model.Entities
{
    public class Module : EntityBase
    {        
        public int IdSystem { get; set; }        
        public int IdModule { get; set; }
        public string FcName { get; set; }
    }
}
