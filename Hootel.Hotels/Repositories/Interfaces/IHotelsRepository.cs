using Hootel.Models;

namespace Hootel.Hotels.Repositories.Interfaces;

public interface IHotelsRepository
{
    Task<List<Hotel>> Get();
    Task<Hotel> Get(int id);
    Task Save(Hotel hotel);
    Task Delete(Hotel hotel);
}