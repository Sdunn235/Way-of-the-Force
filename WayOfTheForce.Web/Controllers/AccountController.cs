using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WayOfTheForce.Web.Models;
using WayOfTheForce.Web.ViewModels;

namespace WayOfTheForce.Web.Controllers;

public class AccountController : Controller
{
    // Identity's two workers. UserManager creates and finds members;
    // SignInManager signs them in and out, and sets the cookie.
    private readonly UserManager<ArchiveMember> _userManager;
    private readonly SignInManager<ArchiveMember> _signInManager;

    public AccountController(UserManager<ArchiveMember> userManager, SignInManager<ArchiveMember> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // GET /Account/Register
    public IActionResult Register()
    {
        return View();
    }

    // POST /Account/Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel form)
    {
        if (!ModelState.IsValid)
        {
            return View(form);
        }

        var member = new ArchiveMember { UserName = form.Email, Email = form.Email };

        // The password goes in; a hash is what gets saved.
        var result = await _userManager.CreateAsync(member, form.Password);

        if (!result.Succeeded)
        {
            // Identity's own reasons: a weak password, an email already taken.
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(form);
        }

        await _signInManager.SignInAsync(member, isPersistent: false);
        return RedirectToAction("Index", "Home");
    }
}
