using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;

public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;

    public AccountController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // Check if email already exists
        if (_context.Users.Any(u => u.Email == model.Email))
        {
            ModelState.AddModelError("Email", "Email is already registered.");
            return View(model);
        }

        // Hash the password before saving
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);

        var user = new User
        {
            Name = model.Name,
            Phone = model.Phone,
            Email = model.Email,
            PasswordHash = hashedPassword
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        TempData["SuccessMessage"] = "Registration successful! You can now login.";
        return RedirectToAction("Login");
    }


     [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
}
