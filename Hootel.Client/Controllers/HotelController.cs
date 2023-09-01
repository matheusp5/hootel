using Hootel.Client.Services.Interfaces;
using Hootel.Client.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Hootel.Client.Controllers;

public class HotelController : Controller
{
    
    private readonly IRoomService _roomService;
    private readonly IHotelService _hotelService;
    private readonly IReservationService _reservationService;
    
    public HotelController(IHotelService hotelService, IRoomService roomService, IReservationService reservationService)
    {
        _hotelService = hotelService;
        _roomService = roomService;
        _reservationService = reservationService;
    }
    
    [HttpGet("hotel/{id}")]
    public async Task<IActionResult> ViewHotel([FromRoute] int id)
    {
        var hotel = await this._hotelService.GetHotel(id);
        var availableRooms = await this._roomService.GetRoomsByHotel(id);
        return View(new HomeHotelViewModel()
        {
            Hotel = hotel,
            AvailableRooms = availableRooms
        });
    }

    [HttpGet("hotel/quarto/{id}")]
    public async Task<IActionResult> Room([FromRoute] int id)
    {
        var room = await _roomService.GetRoom(id);
        var hotel = await _hotelService.GetHotel(room.HotelId);
        var reservations = (await _reservationService.GetAllReservations()).Where(x => x.RoomId == id).ToList();
        return View(new HotelRoomViewModel()
        {
            Room = room,
            Hotel = hotel,
            Reservations = reservations
        });
    }
}