using MediatR;
using Microsoft.EntityFrameworkCore;
using WynajemMaszyn.Infrastructure;
using WynajemMaszyn.Infrastructure.Persistance.Seeders;

namespace WynajemMaszyn.IntegrationTests;

public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>
{
    private readonly IServiceScope _scope;
    protected readonly ISender Sender;
    protected readonly ApplicationDbContext DbContext;
    
    protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
    {
        _scope = factory.Services.CreateScope();
        var services = _scope.ServiceProvider;
        var seeder = services.GetRequiredService<Seeder>();
        Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
        DbContext = _scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        DbContext.Database.Migrate();
        seeder.SeedRolesAsync();
    }
}