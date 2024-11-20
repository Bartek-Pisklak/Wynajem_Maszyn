using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WynajemMaszyn.Domain.Enums;

namespace WynajemMaszyn.Application.Features.Excavators.Queries.DTOs
{
    public class GetAllExcavatorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TypeExcavator TypeExcavator { get; set; }
        public TypeChassis TypeChassis { get; set; }
        public float RentalPricePerDay { get; set; }

        public int ProductionYear { get; set; }
        public int OperatingHours { get; set; }
        public int Weight { get; set; }

        public string Engine { get; set; }
        public int EnginePower { get; set; }
        public int DrivingSpeed { get; set; }
        public int FuelConsumption { get; set; }
        public FuelType FuelType { get; set; }
        public string Gearbox { get; set; }
        public int MaxDiggingDepth { get; set; }

        public string ImagePath { get; set; }
        public string Description { get; set; }
        public bool IsRepair { get; set; }
    }
}
