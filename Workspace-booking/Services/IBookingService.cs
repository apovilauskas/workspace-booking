using Workspace_booking.Common;
using Workspace_booking.Models;

namespace Workspace_booking.Services;

public interface IBookingService
{
    Task<IEnumerable<Room>> GetAvailableRoomsAsync();
    Task<IEnumerable<Booking>> GetBookingsAsync(); 
    Task<Result>BookRoomAsync (Booking booking);
    Task<Result> UnBookRoomAsync (int bookingId);

}