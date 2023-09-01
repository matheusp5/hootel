using Hootel.Client.DTO;
using Hootel.Models;

namespace Hootel.Client.ViewModel;

public class ReservationFormViewModel
{
    public Room Room { get; set; }
    public Hotel Hotel { get; set; }
    public ReservationDTO DTO { get; set; }
}