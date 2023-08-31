namespace Hootel.Rooms.Services.Interfaces;

public interface IReservationService
{
    Task<List<int>> GetReservedRooms(DateTime CheckIn, DateTime CheckOut);
}