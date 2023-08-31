using Hootel.Client.Services.Interfaces;
using Hootel.Models;

namespace Hootel.Client.Services;

public class HotelService : IHotelService
{
    private readonly HttpClient _httpClient;

    public HotelService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:5161"); 
    }
    
    public async Task<List<Hotel>> GetAllHotels(int q = 0)
    {
        var response = await _httpClient.GetAsync($"api/hotels?q={q}");
        return await response.Content.ReadFromJsonAsync<List<Hotel>>();
    }

    public async Task<Hotel> GetHotel(int id)
    {
        var response = await _httpClient.GetAsync($"api/hotels/{id}");
        return await response.Content.ReadFromJsonAsync<Hotel>();
    }

    public async Task CreateHotel(Hotel hotel)
    {
         await _httpClient.PostAsJsonAsync("api/hotels", hotel);
    }

    public async Task DeleteHotel(int id)
    {
        await _httpClient.DeleteAsync($"api/hotels/{id}");
    }
}