using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EmployeePortal.Data;
using EmployeePortal.Areas.Identity.Data;
using EmployeePortal;
using Testing;
using MySql.Data.MySqlClient;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using FluentAssertions.Common;


var builder = WebApplication.CreateBuilder(args);




// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();





builder.Services.AddScoped<IDbConnection>((s) =>
{
    IDbConnection conn = new MySqlConnection(builder.Configuration.GetConnectionString("EmployeePortalDB"));
    conn.Open();
    return conn;
});

builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();


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
app.MapRazorPages();

app.Run();
