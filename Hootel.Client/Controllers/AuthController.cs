using System.Diagnostics;
using System.Security.Claims;
using Hootel.Client.DTO;
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
    public async Task<IActionResult> PostLogin(LoginDTO dto)
    {
        var user = await this._userManager.FindByEmailAsync(dto.Email);
        if (user != null)
        {
            var result = await this._signInManager.PasswordSignInAsync(user, dto.Password, true, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        ViewBag.Error = "E-mail ou senha incorretos";
        return View("Login");
    }

    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await this._signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
    
    
    [HttpPost("register")]
    public async Task<IActionResult> PostRegister(RegisterDTO dto)
    {
        var result = await this._userManager.CreateAsync(new ApplicationUser()
        {
            Email = dto.Email,
            UserName = dto.Name
        }, dto.Password);
        if (result.Succeeded)
        {
            var user = await this._userManager.FindByEmailAsync(dto.Email);
            if (!(await this._roleManager.RoleExistsAsync("user")))
            {
                await this._roleManager.CreateAsync(new()
                {
                    Name = "user"
                });
            }
            
            result = await this._userManager.AddToRoleAsync(user, "user");
            if (result.Succeeded)
            {
                await this._userManager.AddClaimsAsync(user, new[]
                {
                    new Claim("email", dto.Email),
                    new Claim("id", user.Id),
                });
            }

            return RedirectToAction("Login");
        }

        return RedirectToAction("Register");
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
