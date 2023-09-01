using Hootel.Models;
using Hootel.Reservations.Infrastructure;
using Hootel.Reservations.Repositories.Interfaces;
using Hootel.Reservations.Utils;
using Microsoft.EntityFrameworkCore;

namespace Hootel.Reservations.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly DatabaseContext _database;

    public ReservationRepository(DatabaseContext database)
    {
        _database = database;
    }

    public async Task<List<Reservation>> Get()
    {
        return await _database.Reservations.ToListAsync();
    }

    public async Task<List<int>> ReservedRooms(DateTime checkIn, DateTime checkOut)
    {
        return await _database.Reservations.Where(r => r.CheckIn < checkOut && r.CheckOut > checkIn)
            .Select(r => r.RoomId)
            .ToListAsync();
    }

    public async Task<Reservation> Get(int id)
    {
        return await _database.Reservations.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<List<Reservation>> GetByUserId(string id)
    {
        return await _database.Reservations.Where(r => r.ApplicationUser == id).ToListAsync();
    }

    public async Task<Reservation> Save(Reservation reservation)
    {
        reservation.ReservationCode = GenerateReservationCode.Generate();
        var reservationAtDatabase = await _database.Reservations.AddAsync(reservation);
        await _database.SaveChangesAsync();
        return reservationAtDatabase.Entity;
    }

    public async Task Delete(Reservation reservation)
    {
        _database.Reservations.Remove(reservation);
        await _database.SaveChangesAsync();
    }
}