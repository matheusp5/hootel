using Hootel.Models;

namespace Hootel.Client.ViewModel;

public class ViewHotelViewModel
{
    public Hotel Hotel { get; set; }
    public List<Room> AvailableRooms { get; set; }
    
}