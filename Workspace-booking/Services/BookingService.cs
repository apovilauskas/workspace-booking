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

    public Task BookRoomAsync(Booking booking)
    {
        Booking newBooking = booking with
        {
            Date = DateTime.Now,
            Id = _bookings.Count + 1
        };
        _bookings.Add(newBooking);
        return Task.CompletedTask;
    }

    public Task UnBookRoomAsync(Booking booking)
    {
        throw new NotImplementedException();
    }

    public Task AddRoomAsync(Room room)
    {
        throw new NotImplementedException();
    }

    public Task RemoveRoomAsync(Room room)
    {
        throw new NotImplementedException();
    }

    public Task GetRoomByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task GetBookingByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

}