using Hootel.Models;

namespace Hootel.Client.Services.Interfaces;

public interface IReservationService
{
    Task<List<Reservation>> GetAllReservations();
    Task CreateReservation(Reservation reservation);
    Task<Reservation> GetReservation(int r);
    Task DeleteReservation(int r);
}