using Workspace_booking.Models;

namespace Workspace_booking.Services;

public interface IBookingService
{
    Task<IEnumerable<Room>> GetRoomsAsync();
    Task<IEnumerable<Booking>> GetBookingsAsync(); 
    Task<(bool IsSuccess, string Message)>BookRoomAsync (Booking booking);
    Task UnBookRoomAsync (Booking booking);
    Task AddRoomAsync (Room room);
    Task RemoveRoomAsync (Room room);
    Task GetRoomByIdAsync (int id);
    Task GetBookingByIdAsync(int id);
    

}