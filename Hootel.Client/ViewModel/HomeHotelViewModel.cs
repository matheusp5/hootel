using Hootel.Models;

namespace Hootel.Client.ViewModel;

public class HomeHotelViewModel
{
    public Hotel Hotel { get; set; }
    public List<Room> AvailableRooms { get; set; }
    
}