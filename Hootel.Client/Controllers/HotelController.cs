using Hootel.Client.Services.Interfaces;
using Hootel.Client.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Hootel.Client.Controllers;

public class HotelController : Controller
{
    
    private readonly IRoomService _roomService;
    private readonly IHotelService _hotelService;

    public HotelController(IHotelService hotelService, IRoomService roomService)
    {
        _hotelService = hotelService;
        _roomService = roomService;
    }
    
    [HttpGet("hotel/{h}")]
    public async Task<IActionResult> ViewHotel([FromRoute] int h)
    {
        var hotel = await this._hotelService.GetHotel(h);
        var availableRooms = await this._roomService.GetRoomsByHotel(h);
        return View(new HomeHotelViewModel()
        {
            Hotel = hotel,
            AvailableRooms = availableRooms
        });
    }

    [HttpGet("hotel/quarto/{r}")]
    public async Task<IActionResult> Room([FromRoute] int r)
    {
        var room = await _roomService.GetRoom(r);
        var hotel = await _hotelService.GetHotel(room.HotelId);
        return View(new HotelRoomViewModel()
        {
            Room = room,
            Hotel = hotel
        });
    }
}