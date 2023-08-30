using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Hootel.Client.Models;
using Microsoft.AspNetCore.Identity;

namespace Hootel.Client.Controllers;

public class AuthController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AuthController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
    }

    [HttpGet("login")]
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpGet("register")]
    public IActionResult Register()
    {
        return View();
    }
    
    
    [HttpPost("login")]
    public async Task PostLogin()
    {
    }
    
    
    [HttpPost("register")]
    public async Task PostRegister()
    {
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}