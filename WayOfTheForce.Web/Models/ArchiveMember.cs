using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WayOfTheForce.Web.Models;

// A member of the archive. Everything Identity needs (the email, the
// password hash, the lockout counters) comes from IdentityUser. This class
// is where the archive's own facts about a member go.
public class ArchiveMember : IdentityUser
{
    // The name a member goes by on the HoloNet. A new column on AspNetUsers.
    [StringLength(40)]
    public string HoloNetHandle { get; set; } = "";
}
