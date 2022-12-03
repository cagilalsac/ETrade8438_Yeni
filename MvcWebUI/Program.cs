using Business.Services;
using DataAccess.Contexts;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Windows Authentication
//string connectionString = "server=.\\SQLEXPRESS;database=ETrade8438;trusted_connection=true;multipleactiveresultsets=true;trustservercertificate=true;";
// SQL Server Authentication
//string connectionString = "server=.\\SQLEXPRESS;database=ETrade8438;user id=sa;password=sa;multipleactiveresultsets=true;trustservercertificate=true;";
string connectionString = builder.Configuration.GetConnectionString("ETradeDb");
#region IoC Container (Inversion of Control Container)
builder.Services.AddDbContext<ETradeContext>(options => options.UseSqlServer(connectionString));
// Autofac veya Ninject
// AddScoped: istek (request) boyunca objenin referansýný (genelde interface veya abstract class) kullandýðýmýz yerde obje (somut class'tan oluþturulacak) bir kere oluþturulur ve yanýt (response) dönene kadar bu obje hayatta kalýr.
// AddSingleton: web uygulamasý baþladýðýnda objenin referansný (genelde interface veya abstract class) kullandýðýmýz yerde obje (somut class'tan oluþturulacak) bir kere oluþturulur ve uygulama çalýþtýðý (IIS üzerinden uygulama durdurulmadýðý veya yeniden baþlatýlmadýðý) sürece bu obje hayatta kalýr.
// AddTransient: istek (request) baðýmsýz ihtiyaç olan objenin referansýný (genelde interface veya abstract class) kullandýðýmýz her yerde bu objeyi new'ler.
//builder.Services.AddSingleton<ProductRepoBase, ProductRepo>();
//builder.Services.AddTransient<ProductRepoBase, ProductRepo>();
builder.Services.AddScoped<ProductRepoBase, ProductRepo>();

builder.Services.AddScoped<IProductService, ProductService>();
#endregion


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
