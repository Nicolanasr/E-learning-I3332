using System.Diagnostics;
using E_Learning_I3332.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning_I3332.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        bool isAuthenticated = false;
        if (!isAuthenticated)
        {
            return Redirect("~/authentication/login");
        }
        else
        {
            return View();
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
