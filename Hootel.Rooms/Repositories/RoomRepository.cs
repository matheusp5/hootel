using Hootel.Models;
using Hootel.Rooms.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Hootel.Rooms.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly DatabaseContext _database;

    public RoomRepository(DatabaseContext database)
    {
        _database = database;
    }

    public async Task<List<Room>> Get()
    {
        return await _database.Rooms.ToListAsync();
    }

    public async Task<Room> Get(int id)
    {
        return await _database.Rooms.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task Save(Room room)
    {
        await _database.Rooms.AddAsync(room);
        await _database.SaveChangesAsync();
    }

    public async Task Delete(Room room)
    { 
        _database.Rooms.Remove(room);
        await _database.SaveChangesAsync();
    }
}