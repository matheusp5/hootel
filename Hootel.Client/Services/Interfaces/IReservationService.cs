using Hootel.Models;

namespace Hootel.Client.Services.Interfaces;

public interface IReservationService
{
    Task<List<Reservation>> GetAllReservations();
    Task<Reservation> CreateReservation(Reservation reservation);
    Task<List<Reservation>> GetByUserId(string id);
    Task<Reservation> GetReservation(int r);
    Task DeleteReservation(int r);
}