using Microsoft.AspNetCore.Mvc;
using Workspace_booking.Models;
using Workspace_booking.Services;

namespace Workspace_booking.Controllers;

public class RoomController : Controller
{
    
    private readonly IBookingService _bookingService;

    public RoomController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    public async Task<IActionResult> Index()
    {
        var rooms = await _bookingService.GetRoomsAsync();
        return View(rooms);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Booking newBooking)
    {
        await _bookingService.AddBookingAsync(newBooking);
        return RedirectToAction(nameof(Index));
    }
    
}