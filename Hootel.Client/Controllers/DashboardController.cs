using Microsoft.AspNetCore.Mvc;

namespace Hootel.Client.Controllers;

public class DashboardController : Controller
{
    public async Task<IActionResult> Dashboard()
    {
        if (User.IsInRole("admin"))
        {
            
            return View("Admin");
        }

        return View("Client");
    }
}