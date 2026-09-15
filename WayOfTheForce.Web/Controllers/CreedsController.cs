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
}