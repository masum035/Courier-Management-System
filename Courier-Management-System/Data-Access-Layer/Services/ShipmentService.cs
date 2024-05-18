using Courier_Management_System.Domain_Layer.Interfaces;

namespace Courier_Management_System.Data_Access_Layer.Services;

public class ShipmentService
{
    private readonly IShipmentRepository _shipmentRepository;

    public ShipmentService(IShipmentRepository shipmentRepository)
    {
        _shipmentRepository = shipmentRepository;
    }
}