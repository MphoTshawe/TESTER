using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using TESTER.Models;

namespace TESTER.Data.Seed
{
    public class IdentitySeed
    {
        public static async Task SeedRolesAndAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            const string adminRole = "Admin";
            const string adminEmail = "junior.maudu16@gmail.com";
            const string adminPassword = "Admin@123";

            // Ensure role exists
            if (!await roleManager.RoleExistsAsync(adminRole))
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }

            // Check if user exists
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,           // Needed for login
                    Email = adminEmail,
                    EmailConfirmed = true            // Prevents login issues if confirmation is required
                };

                var result = await userManager.CreateAsync(adminUser, adminPassword);

                if (!result.Succeeded)
                {
                    throw new Exception("Failed to create admin: " +
                        string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }

            // Add user to role if not already
            if (!await userManager.IsInRoleAsync(adminUser, adminRole))
            {
                await userManager.AddToRoleAsync(adminUser, adminRole);
            }
        }
    }
}