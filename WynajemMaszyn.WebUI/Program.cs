using WynajemMaszyn.WebUI.Data;
using WynajemMaszyn.Application;
using WynajemMaszyn.Infrastructure;

using WynajemMaszyn.Api.Data;
using WynajemMaszyn.Infrastructure.Persistance.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<WeatherForecastService>();
builder.Services.AddScoped<ApiController>();

builder.Services.AddScoped<ExcavatorService>();
builder.Services.AddScoped<HarvesterService>();
builder.Services.AddScoped<RollerService>();
builder.Services.AddScoped<WoodChipperService>();

builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAuthorization(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var seeder = services.GetRequiredService<Seeder>();

    // Seed permissions
    await seeder.SeedPermissionsAsync();
}

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapControllers();
app.Run();


public partial class Program { }


