

namespace WynajemMaszyn.Domain.Entities
{
    public class Harvester
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Name { get; set; }

        public int ProductionYear { get; set; }
        public int OperatingHours { get; set; }
        public int Weight { get; set; }

        public int EnginePower { get; set; } // KM
        public string FuelType { get; set; } // Typ paliwa (ropa, benzyna)
        public int FuelConsumption { get; set; } // Zużycie paliwa (l/h)
        public int MaxSpeed { get; set; } // Maksymalna prędkość (km/h)
        public int CuttingDiameter { get; set; } // Średnica cięcia (w mm)
        public int MaxReach { get; set; } // Maksymalny zasięg ramienia (w metrach)

        public string WheelType { get; set; } // Typ podwozia (kołowy, gąsienicowy)
        public float RentalPricePerDay { get; set; }


        public string ImagePath { get; set; }
        public string Description { get; set; }


        public virtual User User { get; set; }
    }
}
