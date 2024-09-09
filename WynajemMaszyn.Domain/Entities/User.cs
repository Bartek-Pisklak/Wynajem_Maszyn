﻿
namespace WynajemMaszyn.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int IdPermision { get; set; } = 1;

        public virtual Permision Permision { get; set; }
    }
}
