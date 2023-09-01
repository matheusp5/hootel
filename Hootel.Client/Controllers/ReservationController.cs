using Hootel.Client.DTO;
using Hootel.Client.Services.Interfaces;
using Hootel.Client.ViewModel;
using Hootel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hootel.Client.Controllers;

public class ReservationController : Controller
{
    private readonly IRoomService _roomService;
    private readonly IHotelService _hotelService;
    private readonly IReservationService _reservationService;
    
    public ReservationController(IRoomService roomService, IHotelService hotelService, IReservationService reservationService)
    {
        _roomService = roomService;
        _hotelService = hotelService;
        _reservationService = reservationService;
    }

    [HttpPost("reserva")]
    public async Task<IActionResult> Reservation(string rId)
    {
        var room = await _roomService.GetRoom(int.Parse(rId));
        var hotel = await _hotelService.GetHotel(room.HotelId);
        return View(new HotelRoomViewModel()
        {
            Room = room,
            Hotel = hotel
        });
    }


    [HttpPost("reservado")]
    public async Task<IActionResult> Reserved(ReservationDTO dto)
    {
        var room = await _roomService.GetRoom(int.Parse(dto.RoomId));
        var availableRooms = await _roomService.GetAvailableRooms(dto.CheckIn, dto.CheckOut);
        
        ViewBag.Available = false;
        if(availableRooms.Contains(room))
        {   
            ViewBag.Available = true;
            await _reservationService.CreateReservation(new Reservation()
            {
                ChekIn = dto.CheckIn,
                CheckOut = dto.CheckOut,
                ApplicationUser =  User.Claims.FirstOrDefault(x => x.Type == "id").Value,
                RoomId = room.Id
            });
        }
        
        return View(new HotelRoomViewModel()
        {
            Room = room,
            Hotel = await _hotelService.GetHotel(room.HotelId)
        });
    }
}