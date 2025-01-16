

using Microsoft.AspNetCore.Http;
using Moq;
using WynajemMaszyn.Domain.Enums;

namespace WynajemMaszyn.Application.UnitTests.TestUtils.Constants
{
    public static partial class Constants
    {
        public static class Roller
        {
            public static Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
            public const int Id = 1;
            public const string Name = "Vibratory Roller Model X1";
            public const int ProductionYear = 2018;
            public const int OperatingHours = 1200;
            public const int Weight = 8500;
            public const string Engine = "444"; 
            public const int EnginePower = 150; 
            public const int DrivingSpeed = 10; 
            public const int FuelConsumption = 12; 
            public const FuelType _FuelType = FuelType.Benzyna;
            public const string Gearbox = "Automatic";
            public const int NumberOfDrums = 2;
            public const RollerType _RollerType = RollerType.wibracyjny;
            public const int DrumWidth = 1500; 
            public const int MaxCompactionForce = 25000; 
            public const bool IsVibratory = true;
            public const bool KnigeAsfalt = true;
            public const float RentalPricePerDay = 300.0f;
            public const string ImagePath = "/images/Vibratory_Roller_Model300.jpg";
            public const string Description = "Highly efficient vibratory roller suitable for asphalt and soil compaction.";
            public const bool IsRepair = false;


        }
    }
}
