namespace WynajemMaszyn.Domain.Entities
{
    public class Excavator
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } // małe,średnie, duże, koparko-ładowarki
        public string TypeChassis { get; set; } // podwozie koła,koparki

        public int ProductionYear { get; set; }
        public int OperatingHours { get; set; }
        public int Weight { get; set; }

        public string Engine { get; set; }
        public int EnginePower { get; set; }
        public int DrivingSpeed { get; set; }
        public int FuelConsumption { get; set; } // 1/h
        public string FuelType { get; set; }  //ropa, benzyna
        public string Gearbox { get; set; }

        public string Description { get; set; }

        public int MaxDiggingDepth { get; set; } 

        public bool HasQuickCoupler { get; set; }

        public virtual ICollection<ExcavatorBucket> ExcavatorBucket { get; set; }
        public virtual User User { get; set; }
    }
}
