using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVIAutomation.Model.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public int IdUserInc { get; set; }
        public int IdUserAlt { get; set; }
        public DateTime FdInc { get; set; }
        public DateTime FdAlt { get; set; }
        public bool FbStatus { get; set; }
    }
}
