

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

        public string Description { get; set; }


        public virtual User User { get; set; }
    }
}
