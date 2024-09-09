
namespace WynajemMaszyn.Domain.Entities
{
    public class Machines
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int IdExcavator { get; set; }
        public int IdExcavatorBucket { get; set; }
        public int IdRoller { get; set; }
        public int IdHarvester { get; set; }
        public int IdWoodChipper { get; set; }


        public virtual ICollection<MachinesRental> MachinesRentals { get; set; }
        public virtual Excavator? Excavator { get; set; } = null;
        public virtual ExcavatorBucket? ExcavatorBucket { get; set; } = null;
        public virtual Roller? Roller { get; set; } = null;
        public virtual Harvester? Harvester { get; set; } = null;
        public virtual WoodChipper? WoodChipper { get; set; } = null;
    }
}
