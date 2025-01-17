using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WynajemMaszyn.Domain.Enums;

namespace WynajemMaszyn.Application.Features.Rollers.Queries.DTOs
{
    public class GetAllRollerDto
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
        public IEnumerable<(int Id, DateTime Start, DateTime End)?> DateBusyAll { get; set; }
        public bool IsRepair { get; set; }
    }
}
