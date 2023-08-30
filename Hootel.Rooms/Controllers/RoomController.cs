using Hootel.Models;
using Hootel.Rooms.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Hootel.Rooms.Controllers;

[Route("api/rooms")]
[ApiController]
public class RoomController : ControllerBase
{
    private readonly IRoomRepository _roomRepository;

    public RoomController(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var hotels = await _roomRepository.Get();
        return Ok(hotels);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Hotel([FromRoute] int id)
    {
        var hotel = await _roomRepository.Get(id);
        return Ok(hotel);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Room hotel)
    {
        await _roomRepository.Save(hotel);
        return StatusCode(201);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove([FromRoute] int id)
    {
        var hotel = await _roomRepository.Get(id);
        await _roomRepository.Delete(hotel);
        return Ok();
    }
}