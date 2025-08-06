using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WelcomeApp.Models;

namespace WelcomeApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

   public IActionResult Index()
{
    ViewBag.Message = "Welcome to the .NET 8 MVP!";
    return View();
}

}
