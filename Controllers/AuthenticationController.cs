using System.Diagnostics;
using System.Security.Claims;
using E_Learning_I3332.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning_I3332.Controllers;

public class AuthenticationController : Controller
{
    public IActionResult Index()
    {
        return Redirect("~/authentication/login");
    }

    [Route("authentication/login")]
    public IActionResult Login(string ReturnUrl)
    {
        TempData["ReturnUrl"] = ReturnUrl;
        return View();
    }

    [Route("authentication/login")]
    [HttpPost]
    public async Task<IActionResult> LoginSave(string email, string ReturnUrl)
    {
        if (email == "nasr528@gmail.com")
        {
            var claims = new List<Claim>
            {
                new Claim("email", email),
                new Claim(ClaimTypes.NameIdentifier, email),
                new Claim("role", "1"),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(claimsPrincipal);
            return Redirect(ReturnUrl ?? "/");
        }
        else
        {
            TempData["error"] = "user not found";
            return View("~/Views/Authentication/login.cshtml");
        }
    }


    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return Redirect("/authentication/login");
    }


    [Route("authentication/forgot-password")]
    [ActionName("forgot-password")]
    public ActionResult ForgotPassword()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
