namespace Hootel.Models;

public class Room : BaseModel
{
    public string Code { get; set; }
    public string Description { get; set; }
    public int RoomNumber { get; set; }
    public int BathroomsNumber { get; set; }
    public decimal DailyPrice { get; set; }
    public int HotelId { get; set; }
}