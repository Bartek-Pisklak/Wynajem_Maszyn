
using System.Reflection.PortableExecutable;

namespace WynajemMaszyn.Domain.Entities
{
    public class WoodChipper
    {
        public int Id { get; set; }
        public int Id_User { get; set; }
        public string Name { get; set; }


        public int ProducitonYear { get; set; }
        public int OperatingHours { get; set; }
        public int Weight { get; set; }

        public string Engine { get; set; }
        public int EnginePower { get; set; }
        public string Gearbox { get; set; }
        public int DrivingSpeed { get; set; }
        public int FuelConsumption { get; set; }


        public int MachineLength { get; set; }
        public int TransportHeight { get; set; }
        public int ChoppingHeight { get; set; }
        public int MachineWidth { get; set; }

        public int FlowMaterial { get; set; }

        public string Description { get; set; }

        public virtual User User { get; set; }
    }
}
