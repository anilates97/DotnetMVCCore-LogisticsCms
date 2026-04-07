using System.Security.Claims;
using LogisticsCMS.Models;
using LogisticsCMS.Services.Security;
using LogisticsCMS.Settings;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LogisticsCMS.Controllers;

public class AccountController : Controller
{
    private readonly AuthSettings _authSettings;
    private readonly IAdminPasswordHasher _passwordHasher;
    private readonly ILogger<AccountController> _logger;

    public AccountController(
        IOptions<AuthSettings> authOptions,
        IAdminPasswordHasher passwordHasher,
        ILogger<AccountController> logger
    )
    {
        _authSettings = authOptions.Value;
        _passwordHasher = passwordHasher;
        _logger = logger;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login(string? returnUrl = null)
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            return RedirectToLocal(returnUrl);
        }

        return View(new LoginViewModel { ReturnUrl = returnUrl });
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        if (
            !string.Equals(model.Username, _authSettings.Username, StringComparison.Ordinal)
            || !_passwordHasher.VerifyPassword(model.Password, _authSettings.PasswordHash)
        )
        {
            _logger.LogWarning(
                "Failed admin login attempt for username {Username}. TraceId: {TraceId}",
                model.Username,
                HttpContext.TraceIdentifier
            );
            ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı.");
            return View(model);
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, _authSettings.DisplayName),
            new(ClaimTypes.NameIdentifier, model.Username),
            new(ClaimTypes.Role, "Admin"),
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal,
            new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8),
            }
        );

        _logger.LogInformation(
            "Admin user {Username} signed in successfully. TraceId: {TraceId}",
            model.Username,
            HttpContext.TraceIdentifier
        );

        return RedirectToLocal(model.ReturnUrl);
    }

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        var username = User.Identity?.Name ?? "Unknown";
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        _logger.LogInformation(
            "Admin user {Username} signed out. TraceId: {TraceId}",
            username,
            HttpContext.TraceIdentifier
        );

        return RedirectToAction(nameof(Login));
    }

    private IActionResult RedirectToLocal(string? returnUrl)
    {
        if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
        {
            return Redirect(returnUrl);
        }

        return RedirectToAction("Index", "Shipment");
    }
}
