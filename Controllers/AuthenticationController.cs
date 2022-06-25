using System.Diagnostics;
using E_Learning_I3332.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning_I3332.Controllers;

public class AuthenticationController : Controller
{
    public IActionResult Index()
    {
        return Redirect("~/authentication/login");
    }

    [Route("authentication/login")]
    public IActionResult Login() 
    {
        return View();
    }

    [Route("authentication/login")]
    [HttpPost]
    public IActionResult LoginSave(string email, string password)
    {
        TempData["email"] = email;
        return View("~/Views/Authentication/login.cshtml", Login);
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
