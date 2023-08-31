namespace Hootel.Models;

public class Reservation : BaseModel
{
    public DateTime ChekIn { get; set; }
    public DateTime CheckOut { get; set; }
    public decimal Total { get; set; }
    public string ApplicationUser { get; set; }
    public int HotelId { get; set; }
    public int RoomId { get; set; }
}