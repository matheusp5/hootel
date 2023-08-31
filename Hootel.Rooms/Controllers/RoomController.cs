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
        var rooms = await _roomRepository.Get();
        return Ok(rooms);
    }
    
    [HttpGet("people/{id}")]
    public async Task<IActionResult> ForPeople([FromRoute] int p)
    {
        var rooms = await _roomRepository.ForPeople(p);
        return Ok(rooms);
    }
    
    [HttpGet("reserved/{id}")]
    public async Task<IActionResult> Reserved([FromRoute] int id)
    {
        await _roomRepository.UpdateReservedRoom(id);
        return Ok();
    }
    
    [HttpGet("hotel/{id}")]
    public async Task<IActionResult> Hotel([FromRoute] int id)
    {
        var rooms = await _roomRepository.GetByHotelId(id);
        return Ok(rooms);
    }

    [HttpGet("room/{id}")]
    public async Task<IActionResult> Room([FromRoute] int id)
    {
        var room = await _roomRepository.Get(id);
        return Ok(room);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Room room)
    {
        await _roomRepository.Save(room);
        return StatusCode(201);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove([FromRoute] int id)
    {
        var room = await _roomRepository.Get(id);
        await _roomRepository.Delete(room);
        return Ok();
    }
}