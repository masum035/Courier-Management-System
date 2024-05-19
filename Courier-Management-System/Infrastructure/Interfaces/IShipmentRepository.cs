using Courier_Management_System.Domain_Layer.Entities;

namespace Courier_Management_System.Domain_Layer.Interfaces;

public interface IShipmentRepository
{
    Task<Shipment?> GetByIdAsync(int id);
    Task<IEnumerable<Shipment>> GetAllAsync();
    Task AddAsync(Shipment shipment);
    Task UpdateAsync(Shipment shipment);
    Task DeleteAsync(int id);
    Task<IEnumerable<Shipment>> SearchByConsignmentNumber(string consignmentNumber);
}