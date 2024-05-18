using Microsoft.AspNet.Identity.EntityFramework;

namespace Courier_Management_System.Domain_Layer.Entities;

public class Admin : IdentityUser
{
    public string FullName { get; set; }
    public DateTime DateJoined { get; set; }
}