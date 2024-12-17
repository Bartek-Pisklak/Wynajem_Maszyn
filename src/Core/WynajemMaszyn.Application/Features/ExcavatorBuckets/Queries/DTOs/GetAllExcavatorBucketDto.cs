
namespace WynajemMaszyn.Application.Features.ExcavatorBuckets.Queries.DTOs
{
    public class GetAllExcavatorBucketDto
    {
    public int Id{ get; set; }
    public string Name{ get; set; }
    public string BucketType{ get; set; }
    public int Weight{ get; set; }
    public float RentalPricePerDay{ get; set; }
    public string ImagePath{ get; set; }
    public bool IsRepair { get; set; }
    }
}
