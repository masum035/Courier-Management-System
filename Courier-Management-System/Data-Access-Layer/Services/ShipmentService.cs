using Courier_Management_System.Data_Access_Layer.DTOs;
using Courier_Management_System.Data_Access_Layer.Interfaces;
using Courier_Management_System.Domain_Layer.Entities;
using Courier_Management_System.Domain_Layer.Interfaces;

namespace Courier_Management_System.Data_Access_Layer.Services;

public class ShipmentService : IShipmentService
{
    private readonly IShipmentRepository _shipmentRepository;

    public ShipmentService(IShipmentRepository shipmentRepository)
    {
        _shipmentRepository = shipmentRepository;
    }

    public async Task<ShipmentDTO?> GetShipmentByIdAsync(int id)
    {
        var shipment = await _shipmentRepository.GetByIdAsync(id);
        if (shipment != null)
            return new ShipmentDTO
            {
                Id = shipment.Id,
                ConsignmentNumber = shipment.ConsignmentNumber,
                PickupDate = shipment.PickupDate,
                Status = shipment.Status,
                ShipperInfo = shipment.ShipperInfo,
                ReceiverInfo = shipment.ReceiverInfo,
                CustomerId = shipment.CustomerId,
                Customer = new CustomerDTO
                {
                    Id = shipment.Customer.Id,
                    FullName = shipment.Customer.FullName,
                    PhoneNumber = shipment.Customer.Email,
                    Address = shipment.Customer.Address,
                    DateJoined = shipment.Customer.DateJoined
                }
            };
        return null;
    }

    public async Task<IEnumerable<ShipmentDTO>> GetAllShipmentsAsync()
    {
        var shipments = await _shipmentRepository.GetAllAsync();
        return shipments.Select(s => new ShipmentDTO
        {
            Id = s.Id,
            ConsignmentNumber = s.ConsignmentNumber,
            PickupDate = s.PickupDate,
            Status = s.Status,
            ShipperInfo = s.ShipperInfo,
            ReceiverInfo = s.ReceiverInfo,
            CustomerId = s.CustomerId,
            Customer = new CustomerDTO
            {
                Id = s.Customer.Id,
                FullName = s.Customer.FullName,
                PhoneNumber = s.Customer.Email,
                Address = s.Customer.Address,
                DateJoined = s.Customer.DateJoined
            }
        }).ToList();
    }

    public async Task AddShipmentAsync(ShipmentDTO shipmentDto)
    {
        var shipment = new Shipment
        {
            Id = new Guid().ToString(),
            ConsignmentNumber = shipmentDto.ConsignmentNumber,
            PickupDate = shipmentDto.PickupDate,
            Status = shipmentDto.Status,
            ShipperInfo = shipmentDto.ShipperInfo,
            ReceiverInfo = shipmentDto.ReceiverInfo,
            CustomerId = shipmentDto.CustomerId
        };
        await _shipmentRepository.AddAsync(shipment);
    }

    public async Task UpdateShipmentAsync(ShipmentDTO shipmentDto)
    {
        var shipment = new Shipment
        {
            Id = shipmentDto.Id,
            ConsignmentNumber = shipmentDto.ConsignmentNumber,
            PickupDate = shipmentDto.PickupDate,
            Status = shipmentDto.Status,
            ShipperInfo = shipmentDto.ShipperInfo,
            ReceiverInfo = shipmentDto.ReceiverInfo,
            CustomerId = shipmentDto.CustomerId
        };
        await _shipmentRepository.UpdateAsync(shipment);
    }

    public async Task DeleteShipmentAsync(int id)
    {
        await _shipmentRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<ShipmentDTO>> SearchShipmentsByConsignmentNumberAsync(string consignmentNumber)
    {
        var shipments = await _shipmentRepository.SearchByConsignmentNumber(consignmentNumber);
        return shipments.Select(s => new ShipmentDTO
        {
            Id = s.Id,
            ConsignmentNumber = s.ConsignmentNumber,
            PickupDate = s.PickupDate,
            Status = s.Status,
            ShipperInfo = s.ShipperInfo,
            ReceiverInfo = s.ReceiverInfo,
            CustomerId = s.CustomerId,
            Customer = new CustomerDTO
            {
                Id = s.Customer.Id,
                FullName = s.Customer.FullName,
                PhoneNumber = s.Customer.Email,
                Address = s.Customer.Address,
                DateJoined = s.Customer.DateJoined
            }
        }).ToList();
    }
}