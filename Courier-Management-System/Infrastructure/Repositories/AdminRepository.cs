using Courier_Management_System.Domain_Layer.Entities;
using Courier_Management_System.Infrastructure.DB;
using Courier_Management_System.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Courier_Management_System.Infrastructure.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AdminRepository(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<Admin?> GetByIdAsync(string id)
    {
        return await _userManager.Users.OfType<Admin>().FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<IEnumerable<Admin?>> GetAllAsync()
    {
        return await _userManager.Users.OfType<Admin>().ToListAsync();
    }

    public async Task AddAsync(Admin? admin, string password)
    {
        var result = await _userManager.CreateAsync(admin, password);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(admin, "Admin");
        }
    }

    public async Task UpdateAsync(Admin? admin)
    {
        await _userManager.UpdateAsync(admin);
    }

    public async Task DeleteAsync(string id)
    {
        var admin = await _userManager.Users.OfType<Admin>().FirstOrDefaultAsync(u => u.Id == id);
        if (admin != null)
        {
            await _userManager.DeleteAsync(admin);
        }
    }
}