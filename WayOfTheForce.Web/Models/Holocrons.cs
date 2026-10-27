using System.ComponentModel.DataAnnotations;

namespace WayOfTheForce.Web.Models;

public class Holocrons
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Holocron title is required.")]
    [StringLength(60, MinimumLength = 2)]
    public string Title { get; set; } = "";

    [StringLength(30, MinimumLength = 1, ErrorMessage = "Holocron author must be between 1 and 30 characters.")]
    public string Author { get; set; } = "";

    [Display(Name = "Galactic year when recorded")]
    [Required(ErrorMessage = "What was the galactic year when recorded?")]
    [Range(0, int.MaxValue, ErrorMessage = "The galactic year must be a positive number.")]
    public int WhenRecorded { get; set; }

    // The foreign key. THIS is the column that exists in the table.
    [Display(Name = "Creed")]
    public int CreedId { get; set; }

    // The navigation property. Not a column. EF fills it in when asked.
    public Creeds? Creed { get; set; }
}
