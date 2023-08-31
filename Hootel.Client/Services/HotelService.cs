using Hootel.Client.Services.Interfaces;
using Hootel.Models;

namespace Hootel.Client.Services;

public class HotelService : IHotelService
{
    private readonly HttpClient _httpClient;

    public HotelService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:5161/api"); 
    }
    
    public async Task<List<Room>> GetAllHotels(int q = 0)
    {
        var response = await _httpClient.GetAsync($"hotels?q={q}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<Room>>();
    }

    public async Task<Room> GetHotel(int id)
    {
        var response = await _httpClient.GetAsync($"hotels/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Room>();
    }

    public async Task CreateHotel(Hotel hotel)
    {
        var response = await _httpClient.PostAsJsonAsync("hotels", hotel);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteHotel(int id)
    {
        var response = await _httpClient.DeleteAsync($"hotels/{id}");
        response.EnsureSuccessStatusCode();
    }
}