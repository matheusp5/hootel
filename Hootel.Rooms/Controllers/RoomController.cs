using Hootel.Models;
using Hootel.Rooms.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Hootel.Rooms.Controllers;

[Route("api/rooms")]
[ApiController]
public class RoomController : ControllerBase
{
    private readonly IRoomsRepository _roomsRepository;

    public RoomController(IRoomsRepository roomsRepository)
    {
        _roomsRepository = roomsRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var hotels = await _roomsRepository.Get();
        return Ok(hotels);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Hotel([FromRoute] int id)
    {
        var hotel = await _roomsRepository.Get(id);
        return Ok(hotel);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Room hotel)
    {
        await _roomsRepository.Save(hotel);
        return StatusCode(201);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove([FromRoute] int id)
    {
        var hotel = await _roomsRepository.Get(id);
        await _roomsRepository.Delete(hotel);
        return Ok();
    }
}