using Microsoft.AspNetCore.Identity;

namespace WayOfTheForce.Web.Models;

// A member of the archive. Everything Identity needs (the email, the
// password hash, the lockout counters) comes from IdentityUser. This class
// is where the archive's own facts about a member will go.
public class ArchiveMember : IdentityUser
{
}
