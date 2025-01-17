
using WynajemMaszyn.Domain.Enums;

namespace WynajemMaszyn.Application.Features.WoodChippers.Queries.DTOs
{
    public class GetWoodChipperDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public float RentalPricePerDay { get; set; }
        public int ProductionYear { get; set; }
        public int OperatingHours { get; set; }
        public int Weight { get; set; }

        public string Engine { get; set; }
        public int EnginePower { get; set; }
        public string Gearbox { get; set; }
        public int DrivingSpeed { get; set; }
        public int FuelConsumption { get; set; }
        public FuelType FuelType { get; set; }

        public int MachineLength { get; set; }
        public int TransportHeight { get; set; }
        public int ChoppingHeight { get; set; }
        public int MachineWidth { get; set; }

        public int FlowMaterial { get; set; }
        public List<string> ImagePath { get; set; }
        public string Description { get; set; }
        public IEnumerable<(DateTime Start, DateTime End)?> DateBusy { get; set; }
        public bool IsRepair {  get; set; }
    }
}
