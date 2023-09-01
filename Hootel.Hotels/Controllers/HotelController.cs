using Hootel.Hotels.Repositories.Interfaces;
using Hootel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hootel.Hotels.Controllers;

[Route("api/hotels")]
[ApiController]
public class HotelController : ControllerBase
{
    private readonly IHotelRepository _hotelRepository;

    public HotelController(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] int q)
    {
        var hotels = await _hotelRepository.Get();
        if (q != 0)
        {
            hotels = await _hotelRepository.GetQuantity(q);
        }
        return Ok(hotels);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Hotel([FromRoute] int id)
    {
        var hotel = await _hotelRepository.Get(id);
        return Ok(hotel);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Hotel hotel)
    {
        var hotelAtDatabase = await _hotelRepository.Save(hotel);
        return StatusCode(201, hotelAtDatabase);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove([FromRoute] int id)
    {
        var hotel = await _hotelRepository.Get(id);
        await _hotelRepository.Delete(hotel);
        return Ok();
    }
}