using Hootel.Models;
using Hootel.Reservations.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hootel.Reservations.Controllers;

[Microsoft.AspNetCore.Components.Route("api/reservations")]
[ApiController]
public class ReservationController : ControllerBase
{
    private readonly IReservationRepository _reservationRepository;

    public ReservationController(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var hotels = await _reservationRepository.Get();
        return Ok(hotels);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Hotel([FromRoute] int id)
    {
        var hotel = await _reservationRepository.Get(id);
        return Ok(hotel);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Reservation reservation)
    {
        await _reservationRepository.Save(reservation);
        return StatusCode(201);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove([FromRoute] int id)
    {
        var hotel = await _reservationRepository.Get(id);
        await _reservationRepository.Delete(hotel);
        return Ok();
    }
}