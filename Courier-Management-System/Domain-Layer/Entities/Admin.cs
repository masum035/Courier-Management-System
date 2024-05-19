using Microsoft.AspNet.Identity.EntityFramework;

namespace Courier_Management_System.Domain_Layer.Entities;

public class Admin : ApplicationUser
{
    public string Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public DateTime DateJoined { get; set; }
}