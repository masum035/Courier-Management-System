namespace Courier_Management_System.Data_Access_Layer.DTOs;

public class CustomerDTO
{
    public string Id { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public DateTime DateJoined { get; set; }
    public ICollection<ShipmentDTO>? Shipments { get; set; }
}