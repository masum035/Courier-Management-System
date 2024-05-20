using Courier_Management_System.Data_Access_Layer.DTOs;
using Courier_Management_System.Data_Access_Layer.Interfaces;
using Courier_Management_System.Domain_Layer.Entities;
using Courier_Management_System.Infrastructure.Interfaces;

namespace Courier_Management_System.Data_Access_Layer.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    
    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<CustomerDTO> GetCustomerByIdAsync(string id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            return new CustomerDTO
            {
                Id = customer.Id,
                FullName = customer.FullName,
                PhoneNumber = customer.Email,
                Address = customer.Address,
                DateJoined = customer.DateJoined,
                Shipments = customer.Shipments?.Select(s => new ShipmentDTO
                {
                    Id = s.Id,
                    ConsignmentNumber = s.ConsignmentNumber,
                    PickupDate = s.PickupDate,
                    Status = s.Status,
                    ShipperInfo = s.ShipperInfo,
                    ReceiverInfo = s.ReceiverInfo,
                    CustomerId = s.CustomerId
                }).ToList()
            };
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return customers.Select(c => new CustomerDTO
            {
                Id = c.Id,
                FullName = c.FullName,
                PhoneNumber = c.Email,
                Address = c.Address,
                DateJoined = c.DateJoined,
                Shipments = c.Shipments?.Select(s => new ShipmentDTO
                {
                    Id = s.Id,
                    ConsignmentNumber = s.ConsignmentNumber,
                    PickupDate = s.PickupDate,
                    Status = s.Status,
                    ShipperInfo = s.ShipperInfo,
                    ReceiverInfo = s.ReceiverInfo,
                    CustomerId = s.CustomerId
                }).ToList()
            }).ToList();
        }

        public async Task AddCustomerAsync(CustomerDTO customerDto, string password)
        {
            var customer = new Customer
            {
                Id = new Guid().ToString(),
                Email = customerDto.PhoneNumber,
                FullName = customerDto.FullName,
                Address = customerDto.Address,
                DateJoined = customerDto.DateJoined
            };
            await _customerRepository.AddAsync(customer, password);
        }

        public async Task UpdateCustomerAsync(CustomerDTO customerDto)
        {
            var customer = new Customer
            {
                Id = customerDto.Id,
                Email = customerDto.PhoneNumber,
                FullName = customerDto.FullName,
                Address = customerDto.Address,
                DateJoined = customerDto.DateJoined
            };
            await _customerRepository.UpdateAsync(customer);
        }

        public async Task DeleteCustomerAsync(string id)
        {
            await _customerRepository.DeleteAsync(id);
        }
}