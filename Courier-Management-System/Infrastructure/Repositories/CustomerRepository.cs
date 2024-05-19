using Courier_Management_System.Domain_Layer.Entities;
using Courier_Management_System.Infrastructure.DB;
using Courier_Management_System.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Courier_Management_System.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly UserManager<ApplicationUser> _userManager;

    public CustomerRepository(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Customer?> GetByIdAsync(string id)
    {
        return await _userManager.Users.OfType<Customer>().FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<List<Customer?>> GetAllAsync()
    {
        return await _userManager.Users.OfType<Customer>().ToListAsync();
    }

    public async Task AddAsync(Customer? customer, string password)
    {
        var result = await _userManager.CreateAsync(customer, password);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(customer, "Customer");
        }
    }

    public async Task UpdateAsync(Customer? customer)
    {
        await _userManager.UpdateAsync(customer);
    }

    public async Task DeleteAsync(string id)
    {
        var customer = await _userManager.Users.OfType<Customer>().FirstOrDefaultAsync(u => u.Id == id);
        if (customer != null)
        {
            await _userManager.DeleteAsync(customer);
        }
    }
}