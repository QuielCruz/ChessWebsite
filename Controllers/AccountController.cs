using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using ChessWebsite.ViewModels;

namespace ChessWebsite.Controllers
{
    public class AccountController : Controller
    {
        private const string ADMIN_USERNAME = "admin";
        private const string ADMIN_PASSWORD = "ChessMaster123!";
        private const string ADMIN_EMAIL = "admin@chessmasters.com";

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.IsAdmin = false;
            ViewBag.IsLoggedIn = false;

            if (User.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.IsAdmin = false;
                ViewBag.IsLoggedIn = false;
                return View(model);
            }

            if (model.Username == ADMIN_USERNAME && model.Password == ADMIN_PASSWORD)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, "1"),
                    new Claim(ClaimTypes.Name, model.Username),
                    new Claim(ClaimTypes.Email, ADMIN_EMAIL),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(2),
                    AllowRefresh = true
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                TempData["SuccessMessage"] = "Welcome back, Admin!";
                return RedirectToAction("AdminPanel", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            ViewBag.IsAdmin = false;
            ViewBag.IsLoggedIn = false;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData["SuccessMessage"] = "You have been logged out successfully.";
            return RedirectToAction("Login", "Account");
        }

        public IActionResult AccessDenied()
        {
            ViewBag.IsAdmin = false;
            ViewBag.IsLoggedIn = false;
            return View();
        }
    }
}