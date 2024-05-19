using Courier_Management_System.Data_Access_Layer.DTOs;

namespace Courier_Management_System.Data_Access_Layer.Interfaces;

public interface ICustomerService
{
    Task<CustomerDTO> GetCustomerByIdAsync(string id);
    Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync();
    Task AddCustomerAsync(CustomerDTO customerDto, string password);
    Task UpdateCustomerAsync(CustomerDTO customerDto);
    Task DeleteCustomerAsync(string id);
}