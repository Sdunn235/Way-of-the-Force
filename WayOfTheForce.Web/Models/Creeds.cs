using System.ComponentModel.DataAnnotations;


namespace WayOfTheForce.Web.Models;

public class Creeds
{
    // The database assigns it. Edit and Delete carry it back in a hidden field.
    public int Id { get; set; }

    [Required(ErrorMessage = "Every alliance needs a name.")]
    [StringLength(50, MinimumLength = 2)]
    [Display(Name = "Alliance Name")]
    public string CreedName { get; set; } = "";

    [Required(ErrorMessage = "Every alliance needs a creed.")]
    [StringLength(100)]
    public string Creed { get; set; } = "";

    // Nullable so the migration can add the column to rows that already exist.
    [StringLength(50)]
    public string? Homeworld { get; set; }

    [Range(-100, 100, ErrorMessage = "Force Affinity runs from {1} (dark) to {2} (light).")]
    [Display(Name = "Force Affinity")]
    public int Affinity { get; set; }

    [Range(0, 1000, ErrorMessage = "Total Holocrons must be between {1} and {2}.")]
    [Display(Name = "Total Holocrons")]
    public int TotalHolocrons { get; set; }

    [Display(Name = "Are They Friendly?")]
    public bool IsFriendly { get; set; }

    public ICollection<Holocrons> Holocrons { get; set; } = new List<Holocrons>();
}
