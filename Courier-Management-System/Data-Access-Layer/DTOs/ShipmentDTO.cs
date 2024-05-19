namespace Courier_Management_System.Data_Access_Layer.DTOs;

public class ShipmentDTO
{
    public string Id { get; set; }
    public string ConsignmentNumber { get; set; }
    public DateTime PickupDate { get; set; }
    public string Status { get; set; }
    public string ShipperInfo { get; set; }
    public string ReceiverInfo { get; set; }
    public string CustomerId { get; set; }
    public CustomerDTO Customer { get; set; }
}