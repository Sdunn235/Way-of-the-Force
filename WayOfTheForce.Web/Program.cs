using WayOfTheForce.Web.Data;
using WayOfTheForce.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<WayOfTheForceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity: who the members are, and the sign-in cookie that remembers them.
// The members live in WayOfTheForceContext, in the same database as the creeds.
builder.Services.AddIdentity<ArchiveMember, IdentityRole>()
    .AddEntityFrameworkStores<WayOfTheForceContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// An empty 404 becomes the Missing page, keeping the 404 status code.
app.UseStatusCodePagesWithReExecute("/Home/Missing");

app.UseRouting();

// Reads the sign-in cookie on every request. Must come before UseAuthorization,
// so the lock knows who you are before it decides.
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();

// Makes the app visible to the project checks — do not remove.
public partial class Program { }
