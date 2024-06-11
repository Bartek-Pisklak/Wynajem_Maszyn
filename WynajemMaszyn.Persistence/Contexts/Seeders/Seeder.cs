using BlazorServerCleanArchitecture.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace WynajemMaszyn.Persistence.Contexts.Seeders;

public class Seeder
{
    private readonly ApplicationDbContext _dbContext;

    public Seeder(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
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