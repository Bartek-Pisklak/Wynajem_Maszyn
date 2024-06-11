
namespace WynajemMaszyn.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Permision { get; set; }

        //public virtual Permision {
    }
}
