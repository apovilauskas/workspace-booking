namespace Workspace_booking.Models.ViewModels;

public class RoomsIndexViewModel
{
    public IEnumerable<Room> AvailableRooms { get; set; } = new List<Room>();
    public IEnumerable<Booking> CurrentBookings { get; set; } = new List<Booking>();
}