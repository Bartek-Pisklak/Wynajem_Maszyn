using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using WynajemMaszyn.Application.Common.Interfaces.Authentication;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Infrastructure.Authentication;
using WynajemMaszyn.Infrastructure.Persistance.Repositories;
using WynajemMaszyn.Infrastructure.Persistance.Seeders;

namespace WynajemMaszyn.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Default"),
                r =>
                    r.MigrationsAssembly(typeof(AssemblyReference).Assembly.ToString())));
            
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