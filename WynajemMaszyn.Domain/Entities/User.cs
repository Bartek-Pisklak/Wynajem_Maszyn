
namespace WynajemMaszyn.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int IdPermission { get; set; } = 1;

        public virtual Permission Permission { get; set; }
    }
}
