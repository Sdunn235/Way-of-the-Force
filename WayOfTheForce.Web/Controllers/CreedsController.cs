using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WayOfTheForce.Web.Data;
using WayOfTheForce.Web.Models;

namespace WayOfTheForce.Web.Controllers;

public class CreedsController : Controller
{   
    private readonly WayOfTheForceContext _context;
    public CreedsController(WayOfTheForceContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View(_context.Creeds.ToList());
    }
    public IActionResult Details(int id)
    {
        var creed = _context.Creeds.FirstOrDefault(c => c.Id == id);

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
    [ValidateAntiForgeryToken]
    public IActionResult Create(Creeds newCreed)
    {
        // Annotations failed (bad or missing input) — hand the same form back
        // with the user's values so the error messages can show.
        if (!ModelState.IsValid)
        {
            return View(newCreed);
        }

        _context.Creeds.Add(newCreed);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
}