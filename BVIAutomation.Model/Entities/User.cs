using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVIAutomation.Model.Entities
{
    public class User : EntityBase
    {
        public int IdUserProfile { get; set; }
        public string FcName { get; set; }
        public string FcEmail { get; set; }
        public DateTime FdLastLogin { get; set; }
    }
}
