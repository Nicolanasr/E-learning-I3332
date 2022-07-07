using System.Collections.Immutable;
using System.Diagnostics;
using System.Security.Claims;
using E_Learning_I3332.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_I3332.Controllers;

public class AuthenticationController : Controller
{
    private readonly MySQLDBContext _db;
    [ActivatorUtilitiesConstructorAttribute]
    public AuthenticationController(MySQLDBContext db)
    {
        _db = db;
    }

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

    [Route("authentication/register")]
    public IActionResult Register(string ReturnUrl)
    {
        TempData["ReturnUrl"] = ReturnUrl;
        return View();
    }

    [Route("authentication/register")]
    [HttpPost]
    public IActionResult RegisterSave(Users user)
    {
        if (ModelState.IsValid)
        {
            _db.Add<Users>(user);
            _db.SaveChanges();
            return Redirect("/");
        }

        return View("register", user);
    }

    [Route("authentication/login")]
    [HttpPost]
    public async Task<IActionResult> LoginSave(Users user, string ReturnUrl)
    {
        Users userDb = _db.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);



        if (userDb != null)
        {
            var claims = new List<Claim>
            {
                new Claim("email", userDb.Email??""),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim("role", user.Role.ToString()),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(claimsPrincipal);
            return Redirect(ReturnUrl ?? "/");
        }
        else
        {
            TempData["error"] = "Email or password does not match!";
            return View("login");
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
