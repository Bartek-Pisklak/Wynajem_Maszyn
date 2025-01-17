namespace WynajemMaszyn.Application.Features.ExcavatorBuckets.Queries.DTOs
{
    public class GetExcavatorBucketDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BucketType { get; set; }
        public int ProductionYear { get; set; }
        public int BucketCapacity { get; set; }
        public int Weight { get; set; }
        public int Width { get; set; }
        public int PinDiameter { get; set; }
        public int ArmWidth { get; set; }
        public int PinSpacing { get; set; }
        public string Material { get; set; }
        public int MaxLoadCapacity { get; set; }
        public float RentalPricePerDay { get; set; }
        //public string CompatibleExcavators { get; set; }
        public List<string> ImagePath { get; set; }
        public string Description { get; set; }
        public IEnumerable<(DateTime Start, DateTime End)?> DateBusy { get; set; }
        public bool IsRepair { get; set; }
    }
}
