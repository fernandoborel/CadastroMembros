using CadastroMembros.Presentation;

var builder = WebApplication.CreateBuilder(args);

// configurar para MVC
builder.Services.AddControllersWithViews();

Setup.AddEntityFrameworkServices(builder);
Setup.AddRegisterServices(builder);
Setup.AddAutoMapperServices(builder);
Setup.AddCookie(builder);


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}");

app.Run();
