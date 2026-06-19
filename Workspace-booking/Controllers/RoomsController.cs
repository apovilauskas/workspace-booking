using Microsoft.AspNetCore.Mvc;
using Workspace_booking.Models;
using Workspace_booking.Models.ViewModels;
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
        var rooms = await _bookingService.GetAvailableRoomsAsync();
        var bookings = await _bookingService.GetBookingsAsync();
        var model = new RoomsIndexViewModel
        {
            AvailableRooms = rooms,
            CurrentBookings = bookings
        };
        return View("Index", model);
    }

    [HttpPost]
    public async Task<IActionResult> BookRoom(Booking newBooking)
    {
        (bool isSuccess, string message) = await _bookingService.BookRoomAsync(newBooking);
        if (isSuccess)
        {
            TempData["SuccessMessage"] = message;
        } else TempData["ErrorMessage"] = message;
        
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> UnbookRoom(int bookingId)
    {
        (bool isSuccess, string message) = await _bookingService.UnBookRoomAsync(bookingId);
        if (isSuccess)
        {
            TempData["SuccessMessage"] = message;
        } else TempData["ErrorMessage"] = message;
        return RedirectToAction(nameof(Index));
    }
    
}