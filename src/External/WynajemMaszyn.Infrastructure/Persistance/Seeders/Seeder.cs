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

    public async Task SeedPermissionsAsync()
    {
        // Define the initial permissions to seed
        var permissions = new List<Permission>
            {
                new Permission { Name = "Client" },
                new Permission { Name = "Worker" },
                new Permission { Name = "Admin" },
            };

        var existingPermissions = await _dbContext.Permissions.ToListAsync();

        if (!existingPermissions.Any())
        {
            // If no permissions exist, add them
            await _dbContext.Permissions.AddRangeAsync(permissions);
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