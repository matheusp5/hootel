using Hootel.Client.Services.Interfaces;
using Hootel.Models;

namespace Hootel.Client.Services;

public class ReservationService : IReservationService
{
    
    private readonly HttpClient _httpClient;

    public ReservationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:5149"); 
    }
    
    public async Task<List<Reservation>> GetAllReservations()
    {
        var response = await _httpClient.GetAsync($"api/reservations");
        return await response.Content.ReadFromJsonAsync<List<Reservation>>();
    }

    public async Task CreateReservation(Reservation reservation)
    {
        await _httpClient.PostAsJsonAsync("api/reservations", reservation);
    }

    public async Task<Reservation> GetReservation(int r)
    {
        var response = await _httpClient.GetAsync($"api/reservations/{r}");
        return await response.Content.ReadFromJsonAsync<Reservation>();
    }

    public async Task DeleteReservation(int r)
    {
        await _httpClient.DeleteAsync($"api/reservations");
    }
}