using Courier_Management_System.Data_Access_Layer.DTOs;

namespace Courier_Management_System.Data_Access_Layer.Interfaces;

public interface IShipmentService
{
    Task<ShipmentDTO?> GetShipmentByIdAsync(int id);
    Task<IEnumerable<ShipmentDTO>> GetAllShipmentsAsync();
    Task AddShipmentAsync(ShipmentDTO shipmentDto);
    Task UpdateShipmentAsync(ShipmentDTO shipmentDto);
    Task DeleteShipmentAsync(int id);
    Task<IEnumerable<ShipmentDTO>> SearchShipmentsByConsignmentNumberAsync(string consignmentNumber);
}