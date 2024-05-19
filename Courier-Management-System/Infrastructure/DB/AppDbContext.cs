using Courier_Management_System.Domain_Layer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Courier_Management_System.Infrastructure.DB;

public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
{
    public DbSet<Shipment?> Shipments { get; set; }
    public DbSet<Customer?> Customers { get; set; }
    public DbSet<Admin?> Admins { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customers");
            entity.Property(c => c.FullName).IsRequired().HasMaxLength(100);
            entity.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(13); 
            entity.Property(c => c.Address).IsRequired().HasMaxLength(200);
            entity.Property(c => c.DateJoined).IsRequired();
            entity.HasMany(c => c.Shipments)
                .WithOne(s => s.Customer)
                .HasForeignKey(s => s.CustomerId);
        });
        
        builder.Entity<Admin>(entity =>
        {
            entity.ToTable("Admins");
            entity.Property(a => a.FullName).IsRequired().HasMaxLength(100);
            entity.Property(a => a.Email).IsRequired().HasMaxLength(100);
            entity.Property(a => a.DateJoined).IsRequired();
        });
        
        builder.Entity<Shipment>(entity =>
        {
            entity.ToTable("Shipments");
            entity.Property(s => s.ConsignmentNumber).IsRequired().HasMaxLength(50);
            entity.Property(s => s.PickupDate).IsRequired();
            entity.Property(s => s.Status).IsRequired().HasMaxLength(50);
            entity.Property(s => s.ShipperInfo).IsRequired().HasMaxLength(200);
            entity.Property(s => s.ReceiverInfo).IsRequired().HasMaxLength(200);
            entity.HasOne(s => s.Customer)
                .WithMany(c => c.Shipments)
                .HasForeignKey(s => s.CustomerId);
        });
    }
}