using Hootel.Client.Services.Interfaces;
using Hootel.Models;

namespace Hootel.Client.Services;

public class RoomService : IRoomService
{
    private readonly HttpClient _httpClient;

    public RoomService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:5146"); 
    }
    
    public async Task<List<Room>> GetAllRooms()
    {
        var response = await _httpClient.GetAsync("api/rooms");
        return await response.Content.ReadFromJsonAsync<List<Room>>();
    }

    public async Task CreateRoom(Room room)
    {
        await _httpClient.PostAsJsonAsync("api/rooms", room);
    }

    public async Task<List<Room>> GetRoomsByPeople(int p)
    {
        var response = await _httpClient.GetAsync($"api/rooms/people?p={p}");
        return await response.Content.ReadFromJsonAsync<List<Room>>();
    }

    public async Task<List<Room>> GetAvailableRooms(DateTime CheckIn, DateTime CheckOut)
    {
        var response = await _httpClient.PostAsJsonAsync("api/rooms/reserved", new
        {
            checkIn = CheckIn,
            checkOut = CheckOut
        });
        return await response.Content.ReadFromJsonAsync<List<Room>>();
    }

    public async Task SetReservedRoom(int r)
    {
        await _httpClient.GetAsync($"api/rooms/reserved/{r}");
    }

    public async Task<List<Room>> GetRoomsByHotel(int h)
    {        
        var response = await _httpClient.GetAsync($"api/rooms/hotel/{h}");
        return await response.Content.ReadFromJsonAsync<List<Room>>();
    }

    public async Task<Room> GetRoom(int r)
    {
        var response = await _httpClient.GetAsync($"api/rooms/room/{r}");
        return await response.Content.ReadFromJsonAsync<Room>();
    }

    public async Task DeleteRoom(int r)
    {
        await _httpClient.DeleteAsync($"api/rooms/{r}");
    }
}