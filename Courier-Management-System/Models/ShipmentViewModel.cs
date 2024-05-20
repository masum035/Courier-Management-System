using System.ComponentModel.DataAnnotations;

namespace Courier_Management_System.Models;

public class ShipmentViewModel
{
    public string Id { get; set; }

    [Required]
    [Display(Name = "Consignment Number")]
    public string ConsignmentNumber { get; set; }

    [Required]
    [Display(Name = "Pickup Date")]
    public DateTime PickupDate { get; set; }

    [Required]
    [Display(Name = "Status")]
    public string Status { get; set; }

    [Required]
    [Display(Name = "Shipper Info")]
    public string ShipperInfo { get; set; }

    [Required]
    [Display(Name = "Receiver Info")]
    public string ReceiverInfo { get; set; }

    [Required]
    [Display(Name = "Customer Id")]
    public string CustomerId { get; set; }
}