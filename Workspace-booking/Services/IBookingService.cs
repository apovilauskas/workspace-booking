using Workspace_booking.Models;

namespace Workspace_booking.Services;

public interface IBookingService
{
    Task<List<Room>> GetRoomsAsync();
    Task<List<Booking>> GetBookingAsync(); 
    Task AddBookingAsync(Booking booking);

}