using System.Diagnostics;
using Hootel.Client.DTO;
using Microsoft.AspNetCore.Mvc;
using Hootel.Client.Models;
using Hootel.Client.Services.Interfaces;
using Hootel.Client.ViewModel;
using Hootel.Models;

namespace Hootel.Client.Controllers;

public class HomeController : Controller
{
    private readonly IHotelService _hotelService;
    private readonly IRoomService _roomService;

    public HomeController(IHotelService hotelService, IRoomService roomService)
    {
        _hotelService = hotelService;
        _roomService = roomService;
    }

    public async Task<IActionResult> Index()
    {
        List<Hotel> hotels = await this._hotelService.GetAllHotels(5);
        return View(hotels);
    }

    [HttpGet("buscar")]
    public async Task<IActionResult> Search([FromQuery] SearchDTO dto)
    {
        ViewBag.AlreadySearch = false;
        if (dto.state == null && dto.people == 0 && dto.city == null && dto.bath == 0 && dto.rooms == 0)
        {
            return View();
        }

        if (dto.state == null || dto.city == null)
        {
            return View();
        }
        
        ViewBag.AlreadySearch = true;

        var query = await _roomService.GetAllRooms();
        var filteredRooms = new List<Room>();
        var optionalFilteredRooms = new List<Room>();

        // filtros obrigatórios
        if (!string.IsNullOrEmpty(dto.state) && !string.IsNullOrEmpty(dto.city))
        {
            foreach (var room in query)
            {
                var hotel = await _hotelService.GetHotel(room.HotelId);
                if (hotel != null && hotel.State == dto.state && hotel.City == dto.city)
                {
                    filteredRooms.Add(room);
                }
            }
        }

        // filtros opcionais
        foreach (var room in filteredRooms)
        {
            if (dto.people == 0 || room.PeopleNumber >= dto.people)
            {
                if (dto.rooms == 0 || room.RoomNumber >= dto.rooms)
                {
                    if (dto.bath == 0 || room.BathroomsNumber >= dto.bath)
                    {
                        optionalFilteredRooms.Add(room);
                    }
                }
            }
        }

        return View(optionalFilteredRooms);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}