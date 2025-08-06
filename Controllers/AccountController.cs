using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
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

        // TODO: Add user creation logic here (database save, password hashing, etc.)

        TempData["SuccessMessage"] = "Registration successful! You can now login.";
        return RedirectToAction("Login");
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // TODO: Add authentication logic here (check credentials, sign in user)

        TempData["SuccessMessage"] = "Login successful!";
        return RedirectToAction("Index", "Home");
    }
}
