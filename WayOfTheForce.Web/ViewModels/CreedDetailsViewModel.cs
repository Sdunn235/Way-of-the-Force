using WayOfTheForce.Web.Models;

namespace WayOfTheForce.Web.ViewModels;

public class CreedDetailsViewModel
{
    public Creeds Creed { get; set; } = null!;
    public List<Creeds> AlsoHere { get; set; } = new();
}
