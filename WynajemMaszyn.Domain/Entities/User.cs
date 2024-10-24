
namespace WynajemMaszyn.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int PermissionId { get; set; } = 1;

        public virtual Permission Permission { get; set; }
        public virtual ICollection<Excavator> Excavator { get; set; }
        public virtual ICollection<ExcavatorBucket> ExcavatorBucket { get; set; }
        public virtual ICollection<Roller> Roller { get; set; }
        public virtual ICollection<Harvester> Harvester { get; set; }
        public virtual ICollection<WoodChipper> WoodChipper { get; set; }
    }
}
