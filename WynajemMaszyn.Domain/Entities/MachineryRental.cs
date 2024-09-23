using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WynajemMaszyn.Domain.Entities
{
    public class MachineryRental
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public IEnumerable<int> IdMachines { get; set; }
        public float Cost { get; set; }
        public DateTime BeginRent { get; set; }
        public DateTime EndRent { get; set; }



        public virtual Machinery Machines { get; set; }
        public virtual User User { get; set; }
    }
}
