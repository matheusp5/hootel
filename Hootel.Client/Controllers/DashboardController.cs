using Hootel.Client.Models;
using Hootel.Client.Services.Interfaces;
using Hootel.Client.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hootel.Client.Controllers;

public class DashboardController : Controller
{
    private readonly IReservationService _reservationService;
    
    public DashboardController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    [Authorize]
    [HttpGet("dashboard")]
    public async Task<IActionResult> Dashboard()
    {
        if (User.IsInRole("admin"))
        {
            return View("Admin");
        }

        var reservations = await _reservationService.GetByUserId(User.Claims.FirstOrDefault(x => x.Type == "id").Value);
        return View("Client", reservations);
    }
}