using Hootel.Models;
using Hootel.Reservations.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hootel.Reservations.Controllers;

[Microsoft.AspNetCore.Components.Route("api/reservations")]
[ApiController]
public class ReservationController : ControllerBase
{
    private readonly IReservationsRepository _reservationsRepository;

    public ReservationController(IReservationsRepository reservationsRepository)
    {
        _reservationsRepository = reservationsRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var hotels = await _reservationsRepository.Get();
        return Ok(hotels);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Hotel([FromRoute] int id)
    {
        var hotel = await _reservationsRepository.Get(id);
        return Ok(hotel);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Reservation reservation)
    {
        await _reservationsRepository.Save(reservation);
        return StatusCode(201);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove([FromRoute] int id)
    {
        var hotel = await _reservationsRepository.Get(id);
        await _reservationsRepository.Delete(hotel);
        return Ok();
    }
}