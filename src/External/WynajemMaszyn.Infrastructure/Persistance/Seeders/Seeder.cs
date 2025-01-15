using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WynajemMaszyn.Domain.Entities;

namespace WynajemMaszyn.Infrastructure.Persistance.Seeders;

public class Seeder
{
    private readonly ApplicationDbContext _dbContext;


    public Seeder(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SeedRolesAsync()
    {
        if (!_dbContext.Roles.Any())
        {
            var roles = new List<IdentityRole>
            {
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "User", NormalizedName = "USER" }
            };

            _dbContext.Roles.AddRange(roles);
            await _dbContext.SaveChangesAsync();
        }
    }


    public void ApplyPendingMigrations()
        {
        if (_dbContext.Database.CanConnect() && _dbContext.Database.IsRelational())
        {
            var pendingMigrations = _dbContext.Database.GetPendingMigrations();
            if (pendingMigrations != null && pendingMigrations.Any())
            {
                _dbContext.Database.Migrate();
            }
        }
    }
}