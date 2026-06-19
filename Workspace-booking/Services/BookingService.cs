using System.Runtime.InteropServices.JavaScript;
using Workspace_booking.Models;

namespace Workspace_booking.Services;

public class BookingService : IBookingService
{
    private readonly List<Room> _rooms = new();
    private readonly List<Booking> _bookings = new();

    public BookingService()
    {
        _rooms.Add(new Room(1, "Sahara Meeting Room", 12, "1st Floor"));
        _rooms.Add(new Room(2, "Amazon Work Room", 2, "Basement Floor"));
        _rooms.Add(new Room(3, "Pacific Conference Hall", 25, "2nd Floor"));
        _rooms.Add(new Room(4, "Gobi Quiet Pod", 1, "1st Floor"));
        _rooms.Add(new Room(5, "Atlantic Creative Studio", 8, "3rd Floor"));
        _rooms.Add(new Room(6, "Arctic Focus Corner", 4, "Basement Floor"));
    }
    
    public Task<IEnumerable<Room>> GetAvailableRoomsAsync()
    {
        var roomsInProgress = _bookings
            .Where(room => DateTime.Now >= room.Date && DateTime.Now < room.Date.AddHours(room.Hours))
            .Select(room => room.Id)
            .ToList();
        var availableRooms = _rooms.Where(room => !roomsInProgress.Contains(room.Id));
        return Task.FromResult(availableRooms.AsEnumerable());
    }

    public Task<IEnumerable<Booking>> GetBookingsAsync()
    {
        var roomsInProgress = _bookings
            .Where(room => DateTime.Now >= room.Date && DateTime.Now < room.Date.AddHours(room.Hours))
            .Select(room => room.Id)
            .ToList();
        return Task.FromResult(_bookings.AsEnumerable());
    }

    public Task<(bool IsSuccess, string Message)> BookRoomAsync(Booking booking)
    {
        var roomIds = _bookings.Select(x => x.RoomId).ToList();
        var availableRooms = _rooms.Where(room => !roomIds.Contains(room.Id)).Select(r => r.Id);
        
        if (!availableRooms.Contains(booking.RoomId))
        {
            return Task.FromResult((false,"Room Not Available"));
        }
        
        Booking newBooking = booking with
        {
            Date = DateTime.Now,
            Id = _bookings.Count + 1
        };
        _bookings.Add(newBooking);  
        return Task.FromResult((true, "Room Booked Successfully"));
    }


    public Task<(bool IsSuccess, string Message)> UnBookRoomAsync(int bookingId)
    {
        var booking = _bookings.FirstOrDefault(x => x.Id == bookingId);
        if (booking == null)
        {
            return Task.FromResult((false, "Cancellation Failed"));
        }
        _bookings.Remove(booking);
        return Task.FromResult((true,  "Booking Cancelled Successfully"));
        
    }

}