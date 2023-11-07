using CadastroMembros.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// configurar para MVC
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MembrosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BDMembros")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();
