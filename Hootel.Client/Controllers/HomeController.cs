using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Hootel.Client.Models;
using Hootel.Client.Services.Interfaces;
using Hootel.Client.ViewModel;

namespace Hootel.Client.Controllers;

public class HomeController : Controller
{
    private readonly IHotelService _hotelService;

    public HomeController(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }

    public async Task<IActionResult> Index()
    {
        var hotels = await this._hotelService.GetAllHotels(5);
        return View(hotels);
    }
    
    [HttpGet("buscar")]
    public async Task<IActionResult> Search()
    {
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}