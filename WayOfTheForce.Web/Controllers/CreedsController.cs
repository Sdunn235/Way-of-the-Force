using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WayOfTheForce.Web.Data;
using WayOfTheForce.Web.Models;
using WayOfTheForce.Web.ViewModels;
using Microsoft.EntityFrameworkCore;

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
        // Include loads the Holocrons in one query so each card can show its count.
        return View(_context.Creeds
            .Include(c => c.Holocrons)
            .ToList());
    }
    public IActionResult Details(int id)
    {
        // Include pulls in the related Holocrons; without it the list is always empty.
        var creed = _context.Creeds
            .Include(c => c.Holocrons)
            .FirstOrDefault(c => c.Id == id);

        if (creed == null)
        {
            return NotFound();       // honest 404
        }

        // One object holds everything the page needs, so the view never casts ViewData.
        var viewModel = new CreedDetailsViewModel
        {
            Creed = creed,
            AlsoHere = creed.Homeworld == null
                ? new List<Creeds>()     // unknown homeworld, nothing to match
                : _context.Creeds
                    .Include(c => c.Holocrons)
                    .Where(c => c.Homeworld == creed.Homeworld && c.Id != creed.Id)
                    .ToList()
        };

        return View(viewModel);
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

    // GET: Creeds/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var creeds = await _context.Creeds.FindAsync(id);
        if (creeds == null)
        {
            return NotFound();
        }
        return View(creeds);
    }

    // POST: Creeds/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,CreedName,Creed,Homeworld,Affinity,TotalHolocrons,IsFriendly")] Creeds creeds)
    {
        if (id != creeds.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(creeds);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreedsExists(creeds.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(creeds);
    }

    // GET: Creeds/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        // Include so the card shows the real count of Holocrons that will be deleted with this Creed.
        var creeds = await _context.Creeds
            .Include(c => c.Holocrons)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (creeds == null)
        {
            return NotFound();
        }

        return View(creeds);
    }

    // POST: Creeds/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var creeds = await _context.Creeds.FindAsync(id);
        if (creeds != null)
        {
            _context.Creeds.Remove(creeds);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    private bool CreedsExists(int id)
    {
        return _context.Creeds.Any(e => e.Id == id);
    }
}