using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Creeds.Web.Models;

namespace Creeds.Web.Controllers;

public class CreedsController : Controller
{
    public IActionResult Index()
    {
        return View(CreedsData.All);
    }
    public IActionResult Details(int id)
    {
        var creed = CreedsData.All.FirstOrDefault(c => c.Id == id);

        if (creed == null)
        {
            return NotFound();       // honest 404
        }

        return View(creed);
    }
    // GET /Creeds/Create — hand the browser an empty form
    public IActionResult Create()
    {
        return View();
    }

    // POST /Creeds/Create — the filled-in form lands here.
    // It prints what arrived to the terminal and gets out of the way. Temporary,
    // and the printing is the point.
    [HttpPost]
    public IActionResult Create(global::Creeds.Web.Models.Creeds creed)
    {
        Console.WriteLine($"── model binding built a {creed.GetType().Name} ──");
        Console.WriteLine($"   Name        {creed.CreedName}");
        Console.WriteLine($"   Creed       {creed.Creed}");
        Console.WriteLine($"   Affinity    {creed.Affinity}   (x2 = {creed.Affinity * 2})");
        Console.WriteLine($"   Holocrons   {creed.TotalHolocrons}");
        Console.WriteLine($"   Friendly    {creed.IsFriendly}");

        return Content("Submitted — look at the terminal 👀");
    }
}