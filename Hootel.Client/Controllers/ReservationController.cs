using Hootel.Client.DTO;
using Hootel.Client.Services.Interfaces;
using Hootel.Client.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Hootel.Client.Controllers;

public class ReservationController : Controller
{
    private readonly IRoomService _roomService;
    private readonly IHotelService _hotelService;
    
    public ReservationController(IRoomService roomService, IHotelService hotelService)
    {
        _roomService = roomService;
        _hotelService = hotelService;
    }

    [HttpPost("reserva")]
    public async Task<IActionResult> Reservation([FromBody] int rId)
    {
        var room = await _roomService.GetRoom(rId);
        var hotel = await _hotelService.GetHotel(room.HotelId);
        return View(new HotelRoomViewModel()
        {
            Room = room,
            Hotel = hotel
        });
    }


    [HttpPost("reservado")]
    public async Task<IActionResult> Reserved([FromBody] ReservationDTO dto)
    {
        // not implemented yet
        throw new Exception();
    }
}