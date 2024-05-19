using Courier_Management_System.Data_Access_Layer.DTOs;
using Courier_Management_System.Data_Access_Layer.Interfaces;
using Courier_Management_System.Domain_Layer.Entities;
using Courier_Management_System.Infrastructure.Interfaces;

namespace Courier_Management_System.Data_Access_Layer.Services;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;
    
    public AdminService(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }
    public async Task<AdminDTO> GetAdminByIdAsync(string id)
    {
        var admin = await _adminRepository.GetByIdAsync(id);
        return new AdminDTO
        {
            Id = admin.Id,
            FullName = admin.FullName,
            Email = admin.Email,
            DateJoined = admin.DateJoined
        };
    }

    public async Task<IEnumerable<AdminDTO>> GetAllAdminsAsync()
    {
        var admins = await _adminRepository.GetAllAsync();
        return admins.Select(a => new AdminDTO
        {
            Id = a.Id,
            FullName = a.FullName,
            Email = a.Email,
            DateJoined = a.DateJoined
        }).ToList();
    }

    public async Task AddAdminAsync(AdminDTO adminDto, string password)
    {
        var admin = new Admin
        {
            Id = new Guid().ToString(),
            FullName = adminDto.FullName,
            Email = adminDto.Email,
            DateJoined = adminDto.DateJoined
        };
        await _adminRepository.AddAsync(admin, password);
    }

    public async Task UpdateAdminAsync(AdminDTO adminDto)
    {
        var admin = new Admin
        {
            Id = adminDto.Id,
            Email = adminDto.Email,
            FullName = adminDto.FullName,
            DateJoined = adminDto.DateJoined
        };
        await _adminRepository.UpdateAsync(admin);
    }

    public async Task DeleteAdminAsync(string id)
    {
        await _adminRepository.DeleteAsync(id);
    }
}