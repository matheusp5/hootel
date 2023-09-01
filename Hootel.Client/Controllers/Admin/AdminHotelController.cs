using Hootel.Client.Models;
using Hootel.Client.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hootel.Client.Controllers.Admin;

public class AdminHotelController : Controller
{
    private readonly IHotelService _hotelService;
    private readonly IRoomService _roomService;
    private readonly IReservationService _reservationService;

    public AdminHotelController(IHotelService hotelService, IRoomService roomService, IReservationService reservationService)
    {
        _hotelService = hotelService;
        _roomService = roomService;
        _reservationService = reservationService;
    }

    public async Task<IActionResult> EditHotels()
    {
        var hotels = await _hotelService.GetAllHotels();
        return View(hotels);
    }
    
    
    public async Task<IActionResult> EditRooms()
    {
        var hotels = await _hotelService.GetAllHotels();
        var rooms = await _roomService.GetAllRooms();
        var hotelRooms = new List<HotelRoom>();

        foreach (var room in rooms)
        {
            var hotelRoom = new HotelRoom()
            {
                Room = room,
                Hotel = hotels.FirstOrDefault(x => x.Id == room.HotelId)
            };
            hotelRooms.Add(hotelRoom);
        }
        return View(hotelRooms);
    }
    
    public async Task<IActionResult> EditReservations()
    {
        var reservations = await _reservationService.GetAllReservations();
        return View(reservations);
    }
}