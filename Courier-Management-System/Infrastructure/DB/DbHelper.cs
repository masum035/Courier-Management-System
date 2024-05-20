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
                Email = "admin@gmail.com", 
                FullName = "Admin User", 
                DateJoined = DateTime.UtcNow
            };
            var result = userManager.CreateAsync(adminUser, "admin123").Result;

            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(adminUser, "Admin").Wait();
            }
        }

        if (userManager.FindByNameAsync("customer").Result == null)
        {
            var customerUser = new Customer { 
                Email = "customer@gmail.com", 
                FullName = "Customer User", 
                Address = "Uttara, Dhaka, Bangladesh", 
                DateJoined = DateTime.UtcNow };
            var result = userManager.CreateAsync(customerUser, "customer123").Result;

            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(customerUser, "Customer").Wait();
            }
        }
    }
}