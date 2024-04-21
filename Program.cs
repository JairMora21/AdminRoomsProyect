
using AdminRooms.Models;
using AdminRooms.Services.Implementacion;
using AdminRooms.Services.Interfaz;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Inicio/Index";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    });

builder.Services.AddDbContext<RoomsDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SQL")));

builder.Services.AddScoped<ICuartosService, CuartosService>();
builder.Services.AddScoped<IHuespedService, HuespedService>();
builder.Services.AddScoped<IFinanzasServices, FinanzasServices>();
builder.Services.AddScoped<IResidenciasService, ResidenciasService>();



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Inicio}/{action=Index}/{id?}");

IWebHostEnvironment env = app.Environment;

//Rotativa.AspNetCore.RotativaConfiguration.Setup(env.WebRootPath, "../");
Rotativa.AspNetCore.RotativaConfiguration.Setup(env.WebRootPath, Path.Combine(env.WebRootPath, "Rotativa", "Windows"));


app.Run();
