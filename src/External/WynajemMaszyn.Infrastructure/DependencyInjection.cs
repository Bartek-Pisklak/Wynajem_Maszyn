using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
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


namespace WynajemMaszyn.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configuration)
    {


        services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                        r =>
                            r.MigrationsAssembly(typeof(AssemblyReference).Assembly.ToString())));
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();


        //services.AddScoped<IUserManagerService, UserService>();

        //services.AddScoped<IdentityUserAccessor>();


        services.AddSingleton<IEmailSender<User>, IdentityNoOpEmailSender>();

        /*        services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("Default"),
                        r =>
                            r.MigrationsAssembly(typeof(AssemblyReference).Assembly.ToString())));*/
        // Konfiguracja Identity
        /*        services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();
        */


        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserContextGetIdService, UserContextGetIdService>();
        services.AddScoped<IMachineryRentalRepository, MachineryRentalRepository>();
        
        services.AddScoped<Seeder>();

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
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.Name = "auth";
                options.LoginPath = "/AuthForm";
                options.Cookie.MaxAge = TimeSpan.FromMinutes(60);
                options.AccessDeniedPath = "/Access-denied";

            });
        services.AddCascadingAuthenticationState();


        return services;
    }
}