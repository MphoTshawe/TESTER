using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TESTER.Data;
using TESTER.Models;



var builder = WebApplication.CreateBuilder(args);

// Configure services
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                      ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireNonAlphanumeric = false; // Adjust password requirements as needed
    options.Password.RequiredLength = 8; // Set minimum password length
    options.Password.RequireUppercase = false; // Require at least one uppercase letter
    options.Password.RequireLowercase = false; // Require at least one lowercase letter
    options.User.RequireUniqueEmail = true; // Require at least one digit
    options.SignIn.RequireConfirmedAccount = false; // Require email confirmation for sign-in
    options.SignIn.RequireConfirmedEmail = false; // Require email confirmation for sign-in
    options.SignIn.RequireConfirmedPhoneNumber = false; // Require phone number confirmation for sign-in
})
 .AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();
builder.Services.AddControllersWithViews();

// Add ASP.NET Core Identity

var app = builder.Build();

// Configure HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Area routing
app.MapAreaControllerRoute(
    name: "AdminArea",
    areaName: "Admin",
    pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");

// Default routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Run Identity seeder


// Add this right before app.Run()

app.MapRazorPages();
app.Run();
