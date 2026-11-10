using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WayOfTheForce.Web.Data;
using WayOfTheForce.Web.Models;
using WayOfTheForce.Web.ViewModels;

namespace WayOfTheForce.Web.Controllers;

// The holocron archive is curated: adding, editing and removing need a
// signed-in member. Only the list stays open to everyone.
[Authorize]
public class HolocronsController : Controller
{
    private readonly WayOfTheForceContext _context;

    public HolocronsController(WayOfTheForceContext context)
    {
        _context = context;
    }

    // GET /Holocrons — every holocron in the archive, with the creed it belongs to.
    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var holocrons = await _context.Holocrons
            .Include(h => h.Creed)
            .OrderBy(h => h.Title)
            .ToListAsync();

        return View(holocrons);
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
        RequireExistingCreed(form);

        if (!ModelState.IsValid)
        {
            form.Creeds = CreedChoices(form.Holocron.CreedId);   // rebuild it
            return View(form);
        }

        _context.Holocrons.Add(form.Holocron);
        await _context.SaveChangesAsync();

        return RedirectToAction("Details", "Creeds", new { id = form.Holocron.CreedId });
    }

    // GET /Holocrons/Edit/5 — the same form as Create, already filled in.
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var holocron = await _context.Holocrons.FindAsync(id);
        if (holocron == null)
        {
            return NotFound();
        }

        var form = new HolocronFormViewModel
        {
            Holocron = holocron,
            Creeds = CreedChoices(holocron.CreedId)
        };

        return View(form);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, HolocronFormViewModel form)
    {
        if (id != form.Holocron.Id)
        {
            return NotFound();
        }

        RequireExistingCreed(form);

        if (!ModelState.IsValid)
        {
            form.Creeds = CreedChoices(form.Holocron.CreedId);   // rebuild it
            return View(form);
        }

        try
        {
            _context.Update(form.Holocron);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            // Someone removed it while this form was open.
            if (!_context.Holocrons.Any(h => h.Id == id))
            {
                return NotFound();
            }
            throw;
        }

        return RedirectToAction("Details", "Creeds", new { id = form.Holocron.CreedId });
    }

    // GET /Holocrons/Delete/5 — asks first, and Include shows which creed loses it.
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var holocron = await _context.Holocrons
            .Include(h => h.Creed)
            .FirstOrDefaultAsync(h => h.Id == id);
        if (holocron == null)
        {
            return NotFound();
        }

        return View(holocron);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var holocron = await _context.Holocrons.FindAsync(id);
        if (holocron != null)
        {
            _context.Holocrons.Remove(holocron);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    // The creed could have been removed after the form loaded; saving would break the foreign key.
    private void RequireExistingCreed(HolocronFormViewModel form)
    {
        if (!_context.Creeds.Any(c => c.Id == form.Holocron.CreedId))
        {
            ModelState.AddModelError("Holocron.CreedId", "Pick a creed that still exists.");
        }
    }

    // One place that knows how to build the list, because every form action needs it.
    private SelectList CreedChoices(int? selected) =>
        new SelectList(_context.Creeds.OrderBy(c => c.CreedName).ToList(), "Id", "CreedName", selected);
}
