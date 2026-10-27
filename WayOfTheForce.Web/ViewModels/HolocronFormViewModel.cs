using Microsoft.AspNetCore.Mvc.Rendering;
using WayOfTheForce.Web.Models;

namespace WayOfTheForce.Web.ViewModels;

public class HolocronFormViewModel
{
    public Holocrons Holocron { get; set; } = new();

    // The "?" is load-bearing: ASP.NET treats a non-nullable property as a
    // required field, and this list is never posted back — it is the choices,
    // not the answer. Without it every submission is refused with
    // "The Creeds field is required", pointing at a full dropdown.
    public SelectList? Creeds { get; set; }
}
