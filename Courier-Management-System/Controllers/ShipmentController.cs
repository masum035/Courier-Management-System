using Courier_Management_System.Data_Access_Layer.DTOs;
using Courier_Management_System.Data_Access_Layer.Interfaces;
using Courier_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Courier_Management_System.Controllers;

// [Authorize(Roles = "Admin")]
public class ShipmentController : Controller
{
    private readonly IShipmentService _shipmentService;

    public ShipmentController(IShipmentService shipmentService)
    {
        _shipmentService = shipmentService;
    }

    public async Task<IActionResult> Index()
    {
        var shipments = await _shipmentService.GetAllShipmentsAsync();
        return View(shipments);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ShipmentViewModel shipmentViewModel)
    {
        if (ModelState.IsValid)
        {
            var shipmentDto = new ShipmentDTO
            {
                ConsignmentNumber = shipmentViewModel.ConsignmentNumber,
                PickupDate = shipmentViewModel.PickupDate,
                Status = shipmentViewModel.Status,
                ShipperInfo = shipmentViewModel.ShipperInfo,
                ReceiverInfo = shipmentViewModel.ReceiverInfo,
                CustomerId = shipmentViewModel.CustomerId
            };
            await _shipmentService.AddShipmentAsync(shipmentDto);
            return RedirectToAction(nameof(Index));
        }

        return View(shipmentViewModel);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var shipment = await _shipmentService.GetShipmentByIdAsync(id);
        if (shipment == null)
        {
            return NotFound();
        }

        var shipmentViewModel = new ShipmentViewModel
        {
            Id = shipment.Id,
            ConsignmentNumber = shipment.ConsignmentNumber,
            PickupDate = shipment.PickupDate,
            Status = shipment.Status,
            ShipperInfo = shipment.ShipperInfo,
            ReceiverInfo = shipment.ReceiverInfo,
            CustomerId = shipment.CustomerId
        };
        return View(shipmentViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ShipmentViewModel shipmentViewModel)
    {
        if (ModelState.IsValid)
        {
            var shipmentDto = new ShipmentDTO
            {
                Id = shipmentViewModel.Id,
                ConsignmentNumber = shipmentViewModel.ConsignmentNumber,
                PickupDate = shipmentViewModel.PickupDate,
                Status = shipmentViewModel.Status,
                ShipperInfo = shipmentViewModel.ShipperInfo,
                ReceiverInfo = shipmentViewModel.ReceiverInfo,
                CustomerId = shipmentViewModel.CustomerId
            };
            await _shipmentService.UpdateShipmentAsync(shipmentDto);
            return RedirectToAction(nameof(Index));
        }

        return View(shipmentViewModel);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var shipment = await _shipmentService.GetShipmentByIdAsync(id);
        if (shipment == null)
        {
            return NotFound();
        }

        return View(shipment);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _shipmentService.DeleteShipmentAsync(id);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        var shipment = await _shipmentService.GetShipmentByIdAsync(id);
        if (shipment == null)
        {
            return NotFound();
        }

        return View(shipment);
    }
}