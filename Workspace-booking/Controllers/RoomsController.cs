using Microsoft.AspNetCore.Mvc;
using Workspace_booking.Models;
using Workspace_booking.Services;

namespace Workspace_booking.Controllers;

public class RoomsController : Controller
{
    
    private readonly IBookingService _bookingService;

    public RoomsController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    public async Task<IActionResult> Index()
    {
        var rooms = await _bookingService.GetRoomsAsync();
        return View("Index", rooms);
    }

    [HttpPost]
    public async Task<IActionResult> BookRoom(Booking newBooking)
    {
        await _bookingService.BookRoomAsync(newBooking);
        return RedirectToAction(nameof(Index));
    }
    
}