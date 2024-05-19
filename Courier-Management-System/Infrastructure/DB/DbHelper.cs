using Courier_Management_System.Domain_Layer.Entities;
using Microsoft.AspNetCore.Identity;
using IdentityRole = Microsoft.AspNetCore.Identity.IdentityRole;

namespace Courier_Management_System.Infrastructure.DB;

public static class DbHelper
{
    public static void SeedRoles(RoleManager<IdentityRole> roleManager)
    {
        if (!roleManager.RoleExistsAsync("Admin").Result)
        {
            var role = new IdentityRole("Admin");
            roleManager.CreateAsync(role).Wait();
        }

        if (!roleManager.RoleExistsAsync("Customer").Result)
        {
            var role = new IdentityRole("Customer");
            roleManager.CreateAsync(role).Wait();
        }
    }
    
    public static void SeedUsers(UserManager<ApplicationUser> userManager)
    {
        if (userManager.FindByNameAsync("admin").Result == null)
        {
            var adminUser = new Admin
            {
                Id = new Guid().ToString(), 
                Email = "admin@example.com", 
                FullName = "Admin User", 
                DateJoined = DateTime.UtcNow
            };
            var result = userManager.CreateAsync(adminUser, "Admin@123").Result;

            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(adminUser, "Admin").Wait();
            }
        }

        if (userManager.FindByNameAsync("customer").Result == null)
        {
            var customerUser = new Customer { 
                PhoneNumber = "01551805248", 
                FullName = "Customer User", 
                Address = "123 Customer St", 
                DateJoined = DateTime.UtcNow };
            var result = userManager.CreateAsync(customerUser, "Customer@123").Result;

            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(customerUser, "Customer").Wait();
            }
        }
    }
}