using Microsoft.AspNetCore.Identity;

namespace WynajemMaszyn.Infrastructure.Persistance.Seeders;

public class Seeder
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public Seeder(RoleManager<IdentityRole> roleManager)
    {
        _roleManager=roleManager;
    }

    public async Task SeedRolesAsync()
    {
        var roles = new List<string> { "Admin", "Worker","Client" };

        foreach (var roleName in roles)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                var role = new IdentityRole
                {
                    Name = roleName,
                    NormalizedName = roleName.ToUpper()
                };

                await _roleManager.CreateAsync(role);
            }
        }
    }
}