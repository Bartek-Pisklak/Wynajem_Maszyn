using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WynajemMaszyn.Domain.Entities
{
    public class MachinesRental
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdMachines { get; set; }
        public float Cost { get; set; }
        public DateTime BeginRent { get; set; }
        public DateTime EndRent { get; set; }



        public virtual Machines Machines { get; set; }
        public virtual User User { get; set; }
    }
}
