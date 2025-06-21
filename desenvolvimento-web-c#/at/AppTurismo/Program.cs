using AppTurismo.Data;
using AppTurismo.Models;
using AppTurismo.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppTurismoContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddRazorPages(options =>
    options.Conventions.AuthorizePage("/CreateDestination"));

// Configurar autenticação
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";
        options.SlidingExpiration = true;
        options.Cookie.Name = "TurismoAuth";
    });

builder.Services.AddAuthorization();

VacationPackage.CapacityReached += (message) =>
    LogService.LogDelegate?.Invoke(string.Format("ALERTA DE CAPACIDADE: {0}", message));

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppTurismoContext>();
    context.Database.EnsureCreated();
}


// app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
    .WithStaticAssets();

app.Run();
