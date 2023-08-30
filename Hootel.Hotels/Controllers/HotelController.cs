using Hootel.Hotels.Repositories.Interfaces;
using Hootel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hootel.Hotels.Controllers;

[Route("api/hotels")]
[ApiController]
public class HotelController : ControllerBase
{
    private readonly IHotelsRepository _hotelsRepository;

    public HotelController(IHotelsRepository hotelsRepository)
    {
        _hotelsRepository = hotelsRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var hotels = await _hotelsRepository.Get();
        return Ok(hotels);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Hotel([FromRoute] int id)
    {
        var hotel = await _hotelsRepository.Get(id);
        return Ok(hotel);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Hotel hotel)
    {
        await _hotelsRepository.Save(hotel);
        return StatusCode(201);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove([FromRoute] int id)
    {
        var hotel = await _hotelsRepository.Get(id);
        await _hotelsRepository.Delete(hotel);
        return Ok();
    }
}