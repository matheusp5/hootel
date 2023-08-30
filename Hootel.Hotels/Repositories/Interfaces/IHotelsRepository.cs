using Hootel.Models;

namespace Hootel.Hotels.Repositories.Interfaces;

public interface IHotelsRepository
{
    List<Hotel> Get();
    Hotel Get(string id);
    void Save(Hotel hotel);
    void Delete(string id);
}