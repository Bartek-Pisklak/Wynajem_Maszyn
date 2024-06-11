using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using WynajemMaszyn.WebUI.Data;
using WynajemMaszyn.Application.Features;
//using WynajemMaszyn. ;


using WynajemMaszyn.Application;
using WynajemMaszyn.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<ExcavatorService>();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
