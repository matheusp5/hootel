using Hootel.Client.DTO;
using Hootel.Models;

namespace Hootel.Client.ViewModel;

public class HotelRoomViewModel
{
    public Room Room { get; set; }
    public Hotel Hotel { get; set; }
    public List<Reservation> Reservations { get; set; }
    public ReservationDTO DTO { get; set; }
}