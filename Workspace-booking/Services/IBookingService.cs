using Workspace_booking.Models;

namespace Workspace_booking.Services;

public interface IBookingService
{
    Task<IEnumerable<Room>> GetAvailableRoomsAsync();
    Task<IEnumerable<Booking>> GetBookingsAsync(); 
    Task<(bool IsSuccess, string Message)>BookRoomAsync (Booking booking);
    Task<(bool IsSuccess, string Message)> UnBookRoomAsync (int bookingId);

}