using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WynajemMaszyn.Domain.Entities
{
    public class ExcavatorBucket
    {
        public int Id { get; set; }
        public int Id_User { get; set; }
        public string Name { get; set; }
        public string Normal {  get; set; }

        public int ProductionYear { get; set; }
        public int BucketCapacity { get; set; }
        public int Weight { get; set; }

        public int Width { get; set; } // Szerokość łyżki (w mm)
        public int PinDiameter { get; set; } // Średnica sworzni (w mm)
        public int ArmWidth { get; set; } // Szerokość ramienia (w mm)
        public int PinSpacing { get; set; } // Rozstaw sworzni (w mm)


        public string Description { get; set; }

        public virtual User User { get; set; }
        public virtual Excavator Excavator { get; set; }
    }
}
