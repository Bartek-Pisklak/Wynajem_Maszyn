

using WynajemMaszyn.Domain.Enums;

namespace WynajemMaszyn.Application.Features.WoodChippers.Queries.DTOs
{
    public class GetAllWoodChipperDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public int OperatingHours { get; set; }
        public string Engine { get; set; }
        public int EnginePower { get; set; }
        public int DrivingSpeed { get; set; }
        public int Weight { get; set; }
        public float RentalPricePerDay { get; set; }
        public string ImagePath { get; set; }
        public bool IsRepair { get; set; }
    }
}
