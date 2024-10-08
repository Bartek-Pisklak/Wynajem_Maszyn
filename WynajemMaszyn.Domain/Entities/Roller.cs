﻿

namespace WynajemMaszyn.Domain.Entities
{
    public class Roller
    {
        public int Id { get; set; }
        public int Id_User { get; set; }
        public string Name { get; set; }

        public int ProductionYear { get; set; }
        public int OperatingHours { get; set; }
        public int Weight { get; set; }

        public int Engine { get; set; }
        public int EnginePower { get; set; }
        public int DrivingSpeed { get; set; }
        public int FuelConsumption { get; set; }
        public string FuelType { get; set; }
        public string Gearbox { get; set; }


        public string RollerType { get; set; } // Typ walca (np. gładki, wibracyjny, siatkowy)
        public int DrumWidth { get; set; } // Szerokość bębna (w mm)
        public int MaxCompactionForce { get; set; } // Maksymalna siła zagęszczania (w kN)
        public bool IsVibratory { get; set; }
        public bool KnigeAsfalt {  get; set; }


        public virtual User User { get; set; }
    }
}
