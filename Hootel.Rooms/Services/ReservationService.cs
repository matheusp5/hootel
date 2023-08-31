using Hootel.Rooms.Services.Interfaces;

namespace Hootel.Rooms.Services;

public class ReservationService : IReservationService
{
    private readonly HttpClient _httpClient;

    public ReservationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:5149");
    }

    public async Task<List<int>> GetReservedRooms(DateTime CheckIn, DateTime CheckOut)
    {
        var response = await _httpClient.PostAsJsonAsync("api/reservations/reserved", new
        {
            CheckIn,
            CheckOut
        });
        return await response.Content.ReadFromJsonAsync<List<int>>();
    }
}