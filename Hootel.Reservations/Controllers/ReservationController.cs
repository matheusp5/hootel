using Hootel.Models;
using Hootel.Reservations.DTO;
using Hootel.Reservations.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hootel.Reservations.Controllers;

[Route("api/reservations")]
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
        var reservations = await _reservationRepository.Get();
        return Ok(reservations);
    }
    
    [HttpPost("reserved")]
    public async Task<IActionResult> GetReserved([FromBody] ReservedDTO dto)
    {
        var rooms = await _reservationRepository.ReservedRooms(dto.CheckIn, dto.CheckOut);
        return Ok(rooms);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Hotel([FromRoute] int id)
    {
        var reservation = await _reservationRepository.Get(id);
        return Ok(reservation);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateReservationDTO dto)
    {
        var reservation = new Reservation()
        {
            ReservationCode = "",
            CheckIn = dto.CheckIn,
            CheckOut = dto.CheckIn,
            Total = dto.Total,
            ClientName = dto.ClientName,
            ClientAddress = dto.ClientAddress,
            ClientCity = dto.ClientCity,
            ClientState = dto.ClientState,
            ApplicationUser = dto.ApplicationUser,
            HotelId = dto.HotelId,
            RoomId = dto.RoomId,
        };
        var reservationAtDatabase = await _reservationRepository.Save(reservation);
        return StatusCode(201, reservationAtDatabase);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove([FromRoute] int id)
    {
        var reservation = await _reservationRepository.Get(id);
        await _reservationRepository.Delete(reservation);
        return Ok();
    }
}