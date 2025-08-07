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
    [Authorize]
    public IActionResult Dashboard()
    {
        var model = new DashboardViewModel
        {
            UserEmail = User.Identity?.Name,
            UserId = User.FindFirst("UserId")?.Value,
            FullName = User.FindFirst("FullName")?.Value
        };

        return View(model);
    }


    // Optional: error page
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
