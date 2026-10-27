using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WayOfTheForce.Web.Data;
using WayOfTheForce.Web.Models;
using WayOfTheForce.Web.ViewModels;

namespace WayOfTheForce.Web.Controllers;

public class HolocronsController : Controller
{
    private readonly WayOfTheForceContext _context;

    public HolocronsController(WayOfTheForceContext context)
    {
        _context = context;
    }

    // GET /Holocrons/Create?creedId=3 — the link from a creed's page passes the id,
    // so the dropdown can come up already on the right creed.
    public IActionResult Create(int? creedId)
    {
        var form = new HolocronFormViewModel
        {
            Holocron = new Holocrons { CreedId = creedId ?? 0 },
            Creeds = CreedChoices(creedId)
        };

        return View(form);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(HolocronFormViewModel form)
    {
        if (!ModelState.IsValid)
        {
            form.Creeds = CreedChoices(form.Holocron.CreedId);   // rebuild it
            return View(form);
        }

        _context.Holocrons.Add(form.Holocron);
        await _context.SaveChangesAsync();

        return RedirectToAction("Details", "Creeds", new { id = form.Holocron.CreedId });
    }

    // One place that knows how to build the list, because two actions need it.
    private SelectList CreedChoices(int? selected) =>
        new SelectList(_context.Creeds.OrderBy(c => c.CreedName).ToList(), "Id", "CreedName", selected);
}
