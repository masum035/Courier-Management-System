using Microsoft.AspNet.Identity.EntityFramework;

namespace Courier_Management_System.Domain_Layer.Entities;

public class Customer: IdentityUser
{
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public DateTime DateJoined { get; set; }
        
    // Navigation property
    public ICollection<Shipment> Shipments { get; set; }
}