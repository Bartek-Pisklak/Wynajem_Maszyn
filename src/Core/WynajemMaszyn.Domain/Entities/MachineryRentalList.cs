using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WynajemMaszyn.Domain.Entities
{
    public class MachineryRentalList
    {
        public int Id { get; set; }
        public int MachineryRentalId { get; set; }
        public int MachineryId { get; set; }

        public virtual MachineryRental? MachineryRental { get; set; }
        public virtual Machinery? Machinery { get; set; }
    }
}
