using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WayOfTheForce.Web.Models;

namespace WayOfTheForce.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    // Every 404 is re-executed here (see Program.cs), so a wrong id still gets the site's
    // layout and a way back. Not named NotFound — Controller already has that method.
    public IActionResult Missing()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
