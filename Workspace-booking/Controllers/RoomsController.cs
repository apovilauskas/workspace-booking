using Microsoft.AspNetCore.Mvc;
using Workspace_booking.Common;
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
        Result result = await _bookingService.BookRoomAsync(newBooking);
        if (result.IsSuccess)
        {
            TempData["SuccessMessage"] = result.Message;
        } else TempData["ErrorMessage"] = result.Message;
        
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> UnbookRoom(int bookingId)
    {
        Result result = await _bookingService.UnBookRoomAsync(bookingId);
        if (result.IsSuccess)
        {
            TempData["SuccessMessage"] = result.Message;
        } else TempData["ErrorMessage"] = result.Message;
        return RedirectToAction(nameof(Index));
    }
    
}