namespace Hootel.Models;

public class Reservation : BaseModel
{
    public string ReservationCode { get; set; }
    public DateTime ChekIn { get; set; }
    public DateTime CheckOut { get; set; }
    public decimal Total { get; set; }
    public string ClientName { get; set; }
    public string ClientAddress { get; set; }
    public string ClientCity { get; set; }
    public string ClientState { get; set; }
    public string ApplicationUser { get; set; }
    public int HotelId { get; set; }
    public int RoomId { get; set; }
}