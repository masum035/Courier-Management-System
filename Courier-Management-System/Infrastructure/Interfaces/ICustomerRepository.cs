using Courier_Management_System.Domain_Layer.Entities;

namespace Courier_Management_System.Infrastructure.Interfaces;

public interface ICustomerRepository
{
    Task<Customer?> GetByIdAsync(string id);
    Task<List<Customer?>> GetAllAsync();
    Task AddAsync(Customer? customer, string password);
    Task UpdateAsync(Customer? customer);
    Task DeleteAsync(string id);
}