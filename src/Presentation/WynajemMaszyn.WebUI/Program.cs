using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using WynajemMaszyn.WebUI.Components;
using WynajemMaszyn.WebUI.Components.Account;
using WynajemMaszyn.Infrastructure;
using WynajemMaszyn.Application;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Infrastructure.Persistance.Seeders;
using Microsoft.AspNetCore.Authentication;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddSingleton<TimeProvider>(TimeProvider.System);
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<IAuthenticationSchemeProvider, AuthenticationSchemeProvider>();
//builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddSingleton<IEmailSender<User>, IdentityNoOpEmailSender>();


builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var seeder = services.GetRequiredService<Seeder>();

    await seeder.SeedRolesAsync();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();


app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
