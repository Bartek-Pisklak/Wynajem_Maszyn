using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WynajemMaszyn.Application.Features.Excavators.Queries.DTOs
{
    public class GetAllExcavatorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string TypeChassis { get; set; }
        public float RentalPricePerDay { get; set; }

        public int ProductionYear { get; set; }
        public int OperatingHours { get; set; }
        public int Weight { get; set; }

        public string Engine { get; set; }
        public int EnginePower { get; set; }
        public int DrivingSpeed { get; set; }
        public int FuelConsumption { get; set; }
        public string FuelType { get; set; }
        public string Gearbox { get; set; }
        public int MaxDiggingDepth { get; set; }

        public string ImagePath { get; set; }
        public string Description { get; set; }
    }
}
