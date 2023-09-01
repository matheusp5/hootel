using Hootel.Client.Models;
using Hootel.Models;

namespace Hootel.Client.ViewModel;

public class DashboardAdminViewModel
{
    public List<HotelRoom> Rooms { get; set; }
    public List<Hotel> Hotels { get; set; }
    public List<Reservation> Reservations { get; set; }
}