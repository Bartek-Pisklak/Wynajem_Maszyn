using WynajemMaszyn.Domain.Enums;

namespace WynajemMaszyn.Application.UnitTests.TestUtils.Constants
{
    public static partial class Constants
    {
        public static class Excavator
        {
            public const int Id = 1;
            public const string Name = "Excavator 3000";
            public const TypeExcavator _TypeExcavator = TypeExcavator.mała;
            public const TypeChassis _TypeChassis = TypeChassis.koła;
            public const float RentalPricePerDay = 250.0f;
            public const int ProductionYear = 2018;
            public const int OperatingHours = 3500;
            public const int Weight = 23000;
            public const string Engine = "Cummins QSB6.7";
            public const int EnginePower = 200;
            public const int DrivingSpeed = 5;
            public const int FuelConsumption = 12;
            public const FuelType _FuelType = FuelType.Benzyna;
            public const string Gearbox = "Automatic";
            public const int MaxDiggingDepth = 6000;
            public const string ImagePath = "/images/excavator_3000.jpg";
            public const string Description = "A powerful excavator suitable for heavy-duty digging operations.";
            public const bool IsRepair = false;
        }
    }
}
