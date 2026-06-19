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
        var roomIds = _bookings.Select(x => x.RoomId).ToList();
        var availableRooms = _rooms.Where(room => !roomIds.Contains(room.Id));
        return Task.FromResult(availableRooms.AsEnumerable());
    }

    public Task<IEnumerable<Booking>> GetBookingsAsync()
    {
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