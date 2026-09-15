using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cryptids.Web.Models;

namespace Cryptids.Web.Controllers;

public class CryptidsController : Controller
{
    public IActionResult Index()
    {
        return View(CryptidData.All);
    }
    public IActionResult Details(int id)
    {
        var cryptid = CryptidData.All.FirstOrDefault(c => c.Id == id);

        if (cryptid == null)
        {
            return NotFound();       // honest 404
        }

        return View(cryptid);
    }
}