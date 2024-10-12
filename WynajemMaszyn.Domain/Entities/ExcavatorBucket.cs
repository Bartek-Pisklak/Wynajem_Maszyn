namespace WynajemMaszyn.Domain.Entities
{
    public class ExcavatorBucket
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Name { get; set; }

        public string BucketType { get; set; } // Typ łyżki (np. kopiąca, skarpowa, hydrauliczna)
        public int ProductionYear { get; set; } 
        public int BucketCapacity { get; set; }
        public int Weight { get; set; }

        // wszystko w MM
        public int Width { get; set; } 
        public int PinDiameter { get; set; }
        public int ArmWidth { get; set; }
        public int PinSpacing { get; set; }

        public string Material { get; set; } // Materiał wykonania (np. stal wysokowytrzymała)
        public int MaxLoadCapacity { get; set; } // Maksymalne obciążenie (w kilogramach)
        public float RentalPricePerDay { get; set; } // Cena wynajmu na dzień
        public string CompatibleExcavators { get; set; } // Zgodne modele koparek

        public string ImagePath { get; set; }
        public string Description { get; set; }

        public virtual User User { get; set; }
        public virtual Excavator Excavator { get; set; }
    }
}
