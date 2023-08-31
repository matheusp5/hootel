using Hootel.Models;

namespace Hootel.Reservations.Repositories.Interfaces;

public interface IReservationRepository
{
    Task<List<Reservation>> Get();
    Task<List<int>> ReservedRooms(DateTime checkIn, DateTime checkOut);
    Task<Reservation> Get(int id);
    Task Save(Reservation reservation);
    Task Delete(Reservation reservation);
}