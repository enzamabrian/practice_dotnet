using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WelcomeApp.Models;
using System.Security.Claims;

namespace WelcomeApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    // Inject logger through constructor
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // Public home page
    [AllowAnonymous]
    public IActionResult Index()
    {
        ViewBag.Message = "Welcome to the .NET 8 MVP!";
        return View();
    }

    // Protected dashboard (requires login)
    [Authorize]
    public IActionResult Dashboard()
    {
        var userEmail = User.Identity?.Name;
        var userId = User.FindFirst("UserId")?.Value;
        var fullName = User.FindFirst("FullName")?.Value;

        ViewBag.UserEmail = userEmail;
        ViewBag.UserId = userId;
        ViewBag.FullName = fullName;

        return View();
    }

    // Optional: error page
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
