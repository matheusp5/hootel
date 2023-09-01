using Hootel.Models;
using Hootel.Rooms.Infrastructure;
using Hootel.Rooms.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hootel.Rooms.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly IReservationService _reservationService;
    private readonly DatabaseContext _database;

    public RoomRepository(DatabaseContext database, IReservationService reservationService)
    {
        _database = database;
        _reservationService = reservationService;
    }

    public async Task<List<Room>> Get()
    {
        return await _database.Rooms.Where(r => !r.isReserved).ToListAsync();
    }

    public async Task<Room> Get(int id)
    {
        return await _database.Rooms.FirstOrDefaultAsync(r => r.Id == id && !r.isReserved);
    }

    public async Task<List<Room>> GetByHotelId(int id)
    {
        return await _database.Rooms.Where(r => r.HotelId == id && !r.isReserved).ToListAsync();
    }

    public async Task<List<Room>> GetAvailableRooms(DateTime checkIn, DateTime checkOut)
    {
        var reservedRoomIds = await _reservationService.GetReservedRooms(checkIn, checkOut);

        var availableRooms = await _database.Rooms
            .Where(r => !reservedRoomIds.Contains(r.Id))
            .ToListAsync();

        return availableRooms;
    }

    public async Task UpdateReservedRoom(int id)
    {
        var room = await this.Get(id);
        room.isReserved = !room.isReserved;
        _database.Rooms.Update(room);
        await _database.SaveChangesAsync();
    }

    public async Task<List<Room>> ForPeople(int people)
    {
        return await _database.Rooms.Where(r => r.PeopleNumber == people && !r.isReserved).ToListAsync();
    }

    public async Task<Room> Save(Room room)
    {
        var roomAtDatabase = await _database.Rooms.AddAsync(room);
        await _database.SaveChangesAsync();
        return roomAtDatabase.Entity;
    }

    public async Task Delete(Room room)
    { 
        _database.Rooms.Remove(room);
        await _database.SaveChangesAsync();
    }
}