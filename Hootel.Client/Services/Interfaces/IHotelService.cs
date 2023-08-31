using Hootel.Models;

namespace Hootel.Client.Services.Interfaces;

public interface IHotelService
{
    Task<List<Hotel>> GetAllHotels(int q = 0);
    Task<Hotel> GetHotel(int id);
    Task CreateHotel(Hotel hotel);
    Task DeleteHotel(int id);
}