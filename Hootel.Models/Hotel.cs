namespace Hootel.Models;

public class Hotel : BaseModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
}