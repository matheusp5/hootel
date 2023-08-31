namespace Hootel.Client.DTO;

// [FromQuery] int people, [FromQuery] int rooms, [FromQuery] int bath, [FromQuery] string state, [FromQuery] string city
public class SearchDTO
{
    public int people { get; set; }
    public int rooms { get; set; }
    public int bath { get; set; }
    public string state { get; set; }
    public string city { get; set; }
}