
using Microsoft.AspNetCore.Http;
using Moq;
using WynajemMaszyn.Domain.Enums;

namespace WynajemMaszyn.Application.UnitTests.TestUtils.Constants
{
    public static partial class Constants
    {
        public static class WoodChipper
        {
            public static Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
            public const int Id = 1;
            public const string Name = "Heavy-Duty Wood Chipper";
            public const float RentalPricePerDay = 320.0f; // cena wynajmu za dzień w PLN
            public const int ProductionYear = 2019;
            public const int OperatingHours = 1500; // liczba przepracowanych godzin
            public const int Weight = 3500; // masa w kg

            public const FuelType _FuelType = FuelType.Benzyna;
            public const string Engine = "V8 Diesel Engine";
            public const int EnginePower = 200; // moc silnika w KM
            public const string Gearbox = "Manual";
            public const int DrivingSpeed = 8; // prędkość jazdy w km/h
            public const int FuelConsumption = 18; // zużycie paliwa w l/h

            public const int MachineLength = 5000; // długość maszyny w mm
            public const int TransportHeight = 2500; // wysokość transportowa w mm
            public const int ChoppingHeight = 800; // maksymalna wysokość cięcia w mm
            public const int MachineWidth = 1800; // szerokość maszyny w mm

            public const int FlowMaterial = 3000; // przepustowość materiału w kg/h

            public const string ImagePath = "/images/wood_chipper_heavy_duty.png";
            public const string Description = "Robust wood chipper suitable for heavy-duty operations with high material throughput.";
            public const bool IsRepair = false;
        }
    } 
}

