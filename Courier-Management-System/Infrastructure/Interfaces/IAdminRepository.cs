using Courier_Management_System.Domain_Layer.Entities;

namespace Courier_Management_System.Infrastructure.Interfaces;

public interface IAdminRepository
{
    Task<Admin?> GetByIdAsync(string id);
    Task<IEnumerable<Admin?>> GetAllAsync();
    Task AddAsync(Admin? admin, string password);
    Task UpdateAsync(Admin? admin);
    Task DeleteAsync(string id);
}