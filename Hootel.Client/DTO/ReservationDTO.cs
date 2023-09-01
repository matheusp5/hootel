namespace Hootel.Client.DTO;

public class ReservationDTO
{
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public string ClientName { get; set; }
    public string ClientAddress { get; set; }
    public string ClientCity { get; set; }
    public string ClientState { get; set; }
    public string RoomId { get; set; }
}