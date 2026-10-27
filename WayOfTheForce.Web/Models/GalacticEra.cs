using System.ComponentModel.DataAnnotations;

namespace WayOfTheForce.Web.Models;

// Galactic calendars, each counted from a turning point in galactic history.
// The name is the short tag shown after a year (32 BBY); Display is the dropdown text.
// Values are explicit so reordering this list never changes rows already saved.
public enum GalacticEra
{
    [Display(Name = "BBY — Before the Battle of Yavin")]
    BBY = 0,

    [Display(Name = "ABY — After the Battle of Yavin")]
    ABY = 1,

    [Display(Name = "BTC — Before the Treaty of Coruscant")]
    BTC = 2,

    [Display(Name = "ATC — After the Treaty of Coruscant")]
    ATC = 3,

    [Display(Name = "GrS — Since the Great ReSynchronization")]
    GrS = 4
}
