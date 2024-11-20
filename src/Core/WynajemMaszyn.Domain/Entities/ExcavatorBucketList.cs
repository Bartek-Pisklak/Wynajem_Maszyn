using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WynajemMaszyn.Domain.Entities
{
    public class ExcavatorBucketList
    {
        public virtual Excavator? Excavator { get; set; }
        public virtual ExcavatorBucket? ExcavatorBucket { get; set; }
    }
}
