using Courier_Management_System.Data_Access_Layer.DTOs;

namespace Courier_Management_System.Data_Access_Layer.Interfaces;

public interface IAdminService
{
    Task<AdminDTO> GetAdminByIdAsync(string id);
    Task<IEnumerable<AdminDTO>> GetAllAdminsAsync();
    Task AddAdminAsync(AdminDTO adminDto, string password);
    Task UpdateAdminAsync(AdminDTO adminDto);
    Task DeleteAdminAsync(string id);
}