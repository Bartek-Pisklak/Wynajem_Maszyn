using WynajemMaszyn.WebUI_server.Components;
using WynajemMaszyn.Application;
using WynajemMaszyn.Infrastructure;
using WynajemMaszyn.Infrastructure.Persistance.Seeders;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDistributedMemoryCache(); // Wymagane dla sesji
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".WynajemMaszyn.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddAuthorization(builder.Configuration);

builder.Services.AddDistributedMemoryCache(); // Wymagane dla sesji
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri("https://localhost:7053/"); 
});


// <><><><><><><><><><><><><><><><><><>

var app = builder.Build();


app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/set-auth-token"))
    {
        if (context.Request.Headers.TryGetValue("Authorization", out var authorizationHeader))
        {
            if (authorizationHeader.ToString().StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                var token = authorizationHeader.ToString()["Bearer ".Length..].Trim();
                context.Response.Cookies.Append("AuthToken", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.Now.AddHours(1)
                });
                context.Response.Redirect("/");
                System.Console.WriteLine(context);
            }
        }
    }

    await next();
});


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var seeder = services.GetRequiredService<Seeder>();

    // Seed permissions
    await seeder.SeedPermissionsAsync();
}

app.UseAuthentication();
app.UseAuthorization();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.UseSession();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

public partial class Program { }