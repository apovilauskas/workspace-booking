using Workspace_booking.Models;

namespace Workspace_booking.Services;

public interface IBookingService
{
    Task<IEnumerable<Room>> GetRoomsAsync();
    Task<IEnumerable<Booking>> GetBookingsAsync(); 
    Task AddBookingAsync(Booking booking);

}