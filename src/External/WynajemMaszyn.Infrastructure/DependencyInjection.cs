using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Application.Persistance.Auth;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Infrastructure.Authentication;
using WynajemMaszyn.Infrastructure.Persistance.Repositories;
using WynajemMaszyn.Infrastructure.Persistance.Seeders;
using WynajemMaszyn.Infrastructure.Services;


namespace WynajemMaszyn.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                r => r.MigrationsAssembly(typeof(AssemblyReference).Assembly.ToString())));
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        }).AddIdentityCookies();




        services.AddScoped<Seeder>();
        

        services.AddScoped<IUserManagerService, UserManagerService>();
        services.AddScoped<ISignInManagerService, SignInManagerService>();
        services.AddScoped<IEmailSenderService, EmailSenderService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        services.AddScoped<IMachineryRentalRepository, MachineryRentalRepository>();
        services.AddScoped<IMachineryRepository, MachineryRepository>();
        services.AddScoped<IExcavatorRepository, ExcavatorRepository>();
        services.AddScoped<IExcavatorBucketRepository, ExcavatorBucketRepository>();
        services.AddScoped<IRollerRepository, RollerRepository>();
        services.AddScoped<IHarvesterRepository, HarvesterRepository>();
        services.AddScoped<IWoodChipperRepository, WoodChipperRepository>();

        services.AddHttpContextAccessor();

        return services;
    }

    public static IServiceCollection AddAuthorization(this IServiceCollection services, IConfiguration configuration)
    {


        return services;
    }
}