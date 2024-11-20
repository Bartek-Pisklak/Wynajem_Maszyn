namespace WynajemMaszyn.Domain.Entities
{
    public class Machinery
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? ExcavatorId { get; set; } = null;
        public int? ExcavatorBucketId { get; set; } = null;
        public int? RollerId { get; set; } = null;
        public int? HarvesterId { get; set; } = null;
        public int? WoodChipperId { get; set; } = null;

        

        public virtual Excavator? Excavator { get; set; }
        public virtual ExcavatorBucket? ExcavatorBucket { get; set; }
        public virtual Roller? Roller { get; set; }
        public virtual Harvester? Harvester { get; set; }
        public virtual WoodChipper? WoodChipper { get; set; }
    }
}
