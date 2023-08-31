using Hootel.Models;

namespace Hootel.Client.Services.Interfaces;

public interface IHotelService
{
    Task<List<Room>> GetAllHotels(int q = 0);
    Task<Room> GetHotel(int id);
    Task CreateHotel(Hotel hotel);
    Task DeleteHotel(int id);
}