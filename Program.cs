using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Options;
using SalesControl.Data;
using SalesControl.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<MyDbContext>();
builder.Services.AddTransient<EmployeesService>();

// Add services to the container.
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    Console.WriteLine("You are in Production environment");
} else
{
    Console.WriteLine("You are in Developement environment");    
    SeedingService seeding = new SeedingService(new MyDbContext());   
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
