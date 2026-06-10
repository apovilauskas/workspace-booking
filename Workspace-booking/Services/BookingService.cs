using Workspace_booking.Models;

namespace Workspace_booking.Services;

public class BookingService : IBookingService
{
    private readonly List<Room> _rooms = new();
    private readonly List<Booking> _bookings = new();

    public BookingService()
    {
        _rooms.Add(new Room(1, "Sahara meeting room", 12, "1st floor"));
        _rooms.Add(new Room(2, "Amazon work room", 2, "2nd floor"));
    }
    
    public Task<IEnumerable<Room>> GetRoomsAsync()
    {
        return Task.FromResult(_rooms.AsEnumerable());
    }

    public Task<IEnumerable<Booking>> GetBookingsAsync()
    {
        return Task.FromResult(_bookings.AsEnumerable());
    }

    public Task AddBookingAsync(Booking booking)
    {
        _bookings.Add(booking);
        return Task.CompletedTask;
    }
    
    
    
}