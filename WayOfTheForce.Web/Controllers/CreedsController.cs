using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WayOfTheForce.Web.Models;

namespace WayOfTheForce.Web.Controllers;

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
    // Invalid → the form comes back with errors. Valid → saved, then back to the list.
    [HttpPost]
    public IActionResult Create(Creeds newCreed)
    {
        // Annotations failed (bad or missing input) — hand the same form back
        // with the user's values so the error messages can show.
        if (!ModelState.IsValid)
        {
            return View(newCreed);
        }

        // Happy path: give it the next id, add it to the list, and redirect
        // so a browser refresh doesn't submit the same alliance again.
        newCreed.Id = CreedsData.All.Max(c => c.Id) + 1;
        CreedsData.All.Add(newCreed);

        return RedirectToAction(nameof(Index));
    }
}