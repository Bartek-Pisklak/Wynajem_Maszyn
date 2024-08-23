using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WynajemMaszyn.Domain.Entities
{
    public class Excavator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ProductionYear { get; set; }
        public int OperatingHours { get; set; }
        public int Weight { get; set; }
        public string Engine {  get; set; }
        public int EnginePower { get; set; }
        public int DrivingSpeed { get; set; }


    }
}
