using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Hootel.Client.Models;
using Hootel.Client.Services.Interfaces;
using Hootel.Client.ViewModel;

namespace Hootel.Client.Controllers;

public class HomeController : Controller
{
    private readonly IRoomService _roomService;
    private readonly IHotelService _hotelService;

    public HomeController(IHotelService hotelService, IRoomService roomService)
    {
        _hotelService = hotelService;
        _roomService = roomService;
    }

    public async Task<IActionResult> Index()
    {
        var hotels = await this._hotelService.GetAllHotels(5);
        return View(hotels);
    }

    [HttpGet("hotel/{id}")]
    public async Task<IActionResult> Hotel([FromRoute] int id)
    {
        var hotel = await this._hotelService.GetHotel(id);
        var availableRooms = await this._roomService.GetRoomsByHotel(id);
        return View(new HomeHotelViewModel()
        {
            Hotel = hotel,
            AvailableRooms = availableRooms
        });
    }
    
    /*
    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] int s)
    {
        var hotel = await this._hotelService.GetHotel(id);
        return View(hotel);
    }
    */
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}