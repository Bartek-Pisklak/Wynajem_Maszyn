using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WynajemMaszyn.Infrastructure.Persistance.Repositories;
using WynajemMaszyn.Infrastructure.Persistance.Seeders;

namespace StudentsDashboard.Infrastructure;

public static class AutomaticMigrations
{
    public static void ApplyPendingMigrations(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var seeder = scope.ServiceProvider.GetRequiredService<Seeder>();
            seeder.ApplyPendingMigrations();
        }
    }
}