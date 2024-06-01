using scan.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<IronicusScanContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));

builder.Services.AddControllersWithViews(/*options => 
{
    options.Conventions.Add(new AreaEndpointRouteConvention
    {
        AreaName = "Admin",
        Order = 2 // Set order to ensure admin routes have priority (optional)
    });
}*/);

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "Admin",
    pattern: "{controller=MangaAdmin}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Admin",
    pattern: "MangaAdmin/Update/{id}",
    defaults: new {controller = "MangaAdmin", action = "Update"}
);
app.Run();
