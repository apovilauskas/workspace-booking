namespace Workspace_booking.Models;

public record Room(int Id, string Name, int Capacity, string BuildingFloor);

public record Booking(int Id, int RoomId, string RoomName, string EmployeeName, DateTime Date, int hours);