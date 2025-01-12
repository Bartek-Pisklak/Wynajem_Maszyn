
using Microsoft.AspNetCore.Identity;

namespace WynajemMaszyn.Domain.Entities
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; } = null!;
        public string? LastName { get; set; } = null!;



        public virtual ICollection<MachineryRental> MachineryRental { get; set; }
        public virtual ICollection<Excavator> Excavator { get; set; }
        public virtual ICollection<ExcavatorBucket> ExcavatorBucket { get; set; }
        public virtual ICollection<Roller> Roller { get; set; }
        public virtual ICollection<Harvester> Harvester { get; set; }
        public virtual ICollection<WoodChipper> WoodChipper { get; set; }
    }
}
