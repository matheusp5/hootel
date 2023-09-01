using Hootel.Client.Models;
using Hootel.Client.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hootel.Client.Controllers.Admin;

public class AdminController : Controller
{
    private readonly IHotelService _hotelService;
    private readonly IRoomService _roomService;
    private readonly IReservationService _reservationService;

    public AdminController(IHotelService hotelService, IRoomService roomService, IReservationService reservationService)
    {
        _hotelService = hotelService;
        _roomService = roomService;
        _reservationService = reservationService;
    }

    [Authorize(Roles = "admin")]
    [HttpGet("admin/hotels")]
    public async Task<IActionResult> ManageHotels()
    {
        var hotels = await _hotelService.GetAllHotels();
        return View(hotels);
    }


    [Authorize(Roles = "admin")]
    [HttpGet("admin/rooms")]
    public async Task<IActionResult> ManageRooms()
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

    [Authorize(Roles = "admin")]
    [HttpGet("admin/reservations")]
    public async Task<IActionResult> ManageReservations()
    {
        var reservations = await _reservationService.GetAllReservations();
        return View(reservations);
    }

    [Authorize]
    [HttpPost("delete/reservation")]
    public async Task<IActionResult> DeleteReservation(string id)
    {
        var reservation = await _reservationService.GetReservation(int.Parse(id));
        var isAdmin = User.IsInRole("admin");
        var isOwner = reservation.ApplicationUser == User.Claims.FirstOrDefault(x => x.Type == "id").Value;

        if (isAdmin || isOwner)
        {
            await _reservationService.DeleteReservation(int.Parse(id));
            return RedirectToAction("Dashboard", "Dashboard");
        }

        return RedirectToAction("Login", "Auth");
    }
    
    [Authorize]
    [HttpPost("delete/hotel")]
    public async Task<IActionResult> DeleteHotel(string id)
    {
        var hotel = await _reservationService.GetReservation(int.Parse(id));
        if (User.IsInRole("admin"))
        {
            await _hotelService.DeleteHotel(int.Parse(id));
            return RedirectToAction("Dashboard", "Dashboard");
        }

        return RedirectToAction("Login", "Auth");
    }
    
    [Authorize]
    [HttpPost("delete/room")]
    public async Task<IActionResult> DeleteRoom(string id)
    {
        var hotel = await _reservationService.GetReservation(int.Parse(id));
        if (User.IsInRole("admin"))
        {
            await _roomService.DeleteRoom(int.Parse(id));
            return RedirectToAction("Dashboard", "Dashboard");
        }

        return RedirectToAction("Login", "Auth");
    }
}