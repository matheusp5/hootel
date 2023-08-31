using Hootel.Models;

namespace Hootel.Client.Services.Interfaces;

public interface IRoomService
{
    Task<List<Room>> GetAllRooms();
    Task CreateRoom(Room room);
    Task<List<Room>> GetRoomsByPeople(int p);
    Task<List<Room>> GetAvailableRooms(DateTime CheckIn, DateTime CheckOut);
    Task SetReservedRoom(int r);
    Task<List<Room>> GetRoomsByHotel(int h);
    Task<Room> GetRoom(int r);
    Task DeleteRoom(int r);
}