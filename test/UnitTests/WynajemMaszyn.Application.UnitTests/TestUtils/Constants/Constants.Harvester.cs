
using Microsoft.AspNetCore.Http;
using Moq;
using WynajemMaszyn.Domain.Enums;

namespace WynajemMaszyn.Application.UnitTests.TestUtils.Constants
{

    public static partial class Constants
    {
        public static class Harvester
        {
            public static Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
            public const int Id = 1;
            public const string Name = "Forestry Harvester Pro";
            public const int ProductionYear = 2021;
            public const int OperatingHours = 950; // liczba przepracowanych godzin
            public const int Weight = 14000; // masa w kg
            public const string Engine = "HHSS32";
            public const int EnginePower = 250; // moc silnika w KM
            public const FuelType _FuelType = FuelType.Ropa;
            public const int FuelConsumption = 20; // zużycie paliwa w l/h
            public const int DrivingSpeed = 40;
            public const int MaxSpeed = 15; // maksymalna prędkość w km/h
            public const int CuttingDiameter = 800; // maksymalna średnica cięcia w mm
            public const int MaxReach = 10; // maksymalny zasięg w metrach
            public const TypeChassis _TypeChassis = TypeChassis.koła;
            public const float RentalPricePerDay = 450.0f; // cena wynajmu za dzień w PLN
            public const string ImagePath = "/images/harvester_pro.png";
            public const string Description = "Efficient forestry harvester with a powerful engine and high cutting capacity.";
            public const bool IsRepair = false;
        }
    }
}
