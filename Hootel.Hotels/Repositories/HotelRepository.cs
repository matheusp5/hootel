using Hootel.Hotels.Infrastructure;
using Hootel.Hotels.Repositories.Interfaces;
using Hootel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hootel.Hotels.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly DatabaseContext _database;

    public HotelRepository(DatabaseContext database)
    {
        _database = database;
    }

    public async Task<List<Hotel>> Get()
    {
        return await _database.Hotels.ToListAsync();
    }
    
    public async Task<List<Hotel>> GetQuantity(int quantity)
    {
        return await _database.Hotels.Take(quantity).ToListAsync();
    }

    public async Task<Hotel> Get(int id)
    {
        return await _database.Hotels.FirstOrDefaultAsync(h => h.Id == id);
    }

    public async Task<Hotel> Save(Hotel hotel)
    {
        var hotelAtDatabase = await _database.Hotels.AddAsync(hotel);
        await _database.SaveChangesAsync();
        return hotelAtDatabase.Entity;
    }

    public async Task Delete(Hotel hotel)
    {
        _database.Hotels.Remove(hotel);
        await _database.SaveChangesAsync();
    }
}