using CarrosWebApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CarrosContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("CarrosDatabase"),
        new MySqlServerVersion(new Version(8, 0, 30))));  // ajusta a versão do MySQL conforme tua instalação

var app = builder.Build();

// Configuração padrão (middleware, endpoints etc)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ModelosCarros}/{action=Index}/{id?}");

app.Run();
