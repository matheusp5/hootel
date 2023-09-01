using Hootel.Client.Models;
using Hootel.Client.Services.Interfaces;
using Hootel.Client.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Hootel.Client.Controllers;

public class DashboardController : Controller
{
    private readonly IHotelService _hotelService;
    private readonly IReservationService _reservationService;
    private readonly IRoomService _roomService;
    
    public DashboardController(IHotelService hotelService, IReservationService reservationService, IRoomService roomService)
    {
        _hotelService = hotelService;
        _reservationService = reservationService;
        _roomService = roomService;
    }

    [HttpGet("dashboard")]
    public async Task<IActionResult> Dashboard()
    {
        if (User.IsInRole("admin"))
        {
            return View("Admin");
        }
        
        return View("Client");
    }
}