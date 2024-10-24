namespace WynajemMaszyn.Domain.Entities
{
    public class Machinery
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int IdExcavator { get; set; }
        public int IdExcavatorBucket { get; set; }
        public int IdRoller { get; set; }
        public int IdHarvester { get; set; }
        public int IdWoodChipper { get; set; }

        public virtual MachineryRental MachineryRental { get; set; }

        public virtual Excavator? Excavator { get; set; }
        public virtual ExcavatorBucket? ExcavatorBucket { get; set; }
        public virtual Roller? Roller { get; set; }
        public virtual Harvester? Harvester { get; set; }
        public virtual WoodChipper? WoodChipper { get; set; }
    }
}
