using Hootel.Models;

namespace Hootel.Client.ViewModel;

public class ReservationReservedViewModel
{
    public Hotel Hotel { get; set; }
    public Room Room { get; set; }
    public Reservation Reservation { get; set; }
}