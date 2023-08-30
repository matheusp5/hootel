using Hootel.Hotels.Infrastructure;
using Hootel.Hotels.Repositories.Interfaces;
using Hootel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hootel.Hotels.Repositories;

public class HotelsRepository : IHotelsRepository
{
    private readonly DatabaseContext _database;

    public HotelsRepository(DatabaseContext database)
    {
        _database = database;
    }

    public async Task<List<Hotel>> Get()
    {
        return await _database.Hotels.ToListAsync();
    }

    public async Task<Hotel> Get(int id)
    {
        return await _database.Hotels.FirstOrDefaultAsync(h => h.Id == id);
    }

    public async Task Save(Hotel hotel)
    {
        await _database.Hotels.AddAsync(hotel);
        await _database.SaveChangesAsync();
    }

    public async Task Delete(Hotel hotel)
    {
        _database.Hotels.Remove(hotel);
        await _database.SaveChangesAsync();
    }
}