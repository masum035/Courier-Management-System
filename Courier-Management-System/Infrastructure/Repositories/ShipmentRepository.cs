using Courier_Management_System.Domain_Layer.Entities;
using Courier_Management_System.Domain_Layer.Interfaces;
using Courier_Management_System.Infrastructure.DB;
using Microsoft.EntityFrameworkCore;

namespace Courier_Management_System.Infrastructure.Repositories;

public class ShipmentRepository : IShipmentRepository
{
    private readonly AppDbContext _context;

    public ShipmentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Shipment?> GetByIdAsync(int id)
    {
        return await _context.Shipments.FindAsync(id);
    }

    public async Task<IEnumerable<Shipment>> GetAllAsync()
    {
        return (await _context.Shipments.ToListAsync())!;
    }

    public async Task AddAsync(Shipment shipment)
    {
        await _context.Shipments.AddAsync(shipment);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Shipment shipment)
    {
        _context.Shipments.Update(shipment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var shipment = await _context.Shipments.FindAsync(id);
        if (shipment != null)
        {
            _context.Shipments.Remove(shipment);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Shipment>> SearchByConsignmentNumber(string consignmentNumber)
    {
        return await _context.Shipments
            .Where(s => s.ConsignmentNumber.Contains(consignmentNumber))
            .ToListAsync();
    }
}