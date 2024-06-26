namespace Courier_Management_System.Domain_Layer.Entities;

public class Shipment
{
    public string Id { get; set; }
    public string  ConsignmentNumber { get; set; }
    public DateTime PickupDate { get; set; }
    public string Status { get; set; }
    public string ShipperInfo { get; set; }
    public string ReceiverInfo { get; set; }
        
    // Foreign key and navigation property
    public string CustomerId { get; set; }
    public Customer Customer { get; set; }
}