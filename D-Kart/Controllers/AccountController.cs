using D_Kart.Domain.Models;
using D_Kart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Threading.Tasks;

public class AccountController : Controller
{
    private readonly ILoginService _loginService;

    public AccountController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpGet]
    public IActionResult LoginPage()
    {
        return View(new LoginViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        // Validate the model state
        if (!ModelState.IsValid)
            return View("LoginPage", model);

        // Authenticate the user
        var user = _loginService.Authenticate(model.Email, model.Password);
        if (user == null)
        {
            ModelState.AddModelError("", "Invalid login credentials.");
            return View("LoginPage", model);
        }

        // Set authentication cookie/session
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Name ?? user.Email),
            new Claim(ClaimTypes.Email, user.Email)
        };
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            new AuthenticationProperties
            {
                IsPersistent = model.RememberMe
            }
        );

        // Redirect to Home/Index after successful login
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View(new RegisterViewModel());
    }

    [HttpPost]
    public IActionResult Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        // Hash the password before saving
        var hashedPassword = HashPassword(model.Password);

        var user = new LoginDetails
        {
            Name = model.Name,
            Email = model.Email,
            Password = hashedPassword,
            RecoveryQuestion = model.RecoveryQuestion,
            RecoveryAnswer = model.RecoveryAnswer,
            RememberMe = false
        };

        if (!_loginService.Register(user, out var error))
        {
            ModelState.AddModelError("", error);
            return View(model);
        }

        // Redirect to LoginPage after successful registration
        return RedirectToAction("LoginPage");
    }

    // Example password hashing method (replace with a secure one in production)
    private string HashPassword(string password)
    {
        // Use a real password hasher like ASP.NET Core Identity's PasswordHasher
        // For demonstration only. DO NOT use this in production.
        return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }
}