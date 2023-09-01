using Hootel.Models;

namespace Hootel.Hotels.Repositories.Interfaces;

public interface IHotelRepository
{
    Task<List<Hotel>> Get();
    Task<List<Hotel>> GetQuantity(int quantity);
    Task<Hotel> Get(int id);
    Task<Hotel> Save(Hotel hotel);
    Task Delete(Hotel hotel);
}