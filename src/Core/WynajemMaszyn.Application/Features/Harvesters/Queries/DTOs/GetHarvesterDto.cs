using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WynajemMaszyn.Domain.Enums;

namespace WynajemMaszyn.Application.Features.Harvesters.Queries.DTOs
{
    public class GetHarvesterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public int OperatingHours { get; set; }
        public int Weight { get; set; }
        public string Engine { get; set; }
        public int DrivingSpeed { get; set; }
        public int EnginePower { get; set; }
        public FuelType FuelType { get; set; }
        public int FuelConsumption { get; set; }
        public int MaxSpeed { get; set; }
        public int CuttingDiameter { get; set; }
        public int MaxReach { get; set; }

        public TypeChassis TypeChassis { get; set; }
        public float RentalPricePerDay { get; set; }


        public List<string> ImagePath { get; set; }
        public string Description { get; set; }
        public IEnumerable<(DateTime Start, DateTime End)?> DateBusy { get; set; }
        public bool IsRepair { get; set; }


    }
}
