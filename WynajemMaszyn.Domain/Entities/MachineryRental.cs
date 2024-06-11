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
        public int IdMachinery { get; set; }
        public int Cost { get; set; }
        public DateTime BeginRent { get; set; }
        public DateTime EndRent { get; set; }

    }
}
