using Microsoft.EntityFrameworkCore;
using Creeds.Web.Models;

namespace Creeds.Web.Data;

public class WayOfTheForceContext : DbContext
{
    public WayOfTheForceContext(DbContextOptions<WayOfTheForceContext> options) : base(options)
    {
    }

    public DbSet<global::Creeds.Web.Models.Creeds> Creeds => Set<global::Creeds.Web.Models.Creeds>();

    // Seed data — the alliances that used to live in CreedsData.cs.
    // Same ids as before, so existing /Creeds/Details/{id} links still work.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<global::Creeds.Web.Models.Creeds>().HasData(
            new global::Creeds.Web.Models.Creeds { Id = 1, CreedName = "Jedi Order",        Creed = "Peacekeepers who serve the light side of the Force",               Affinity = 95,  TotalHolocrons = 0, IsFriendly = true  },
            new global::Creeds.Web.Models.Creeds { Id = 2, CreedName = "Sith Order",        Creed = "Power through passion and mastery of the dark side",               Affinity = -95, TotalHolocrons = 0, IsFriendly = false },
            new global::Creeds.Web.Models.Creeds { Id = 3, CreedName = "Rebel Alliance",    Creed = "Freedom and hope against Imperial tyranny",                        Affinity = 70,  TotalHolocrons = 0, IsFriendly = true  },
            new global::Creeds.Web.Models.Creeds { Id = 4, CreedName = "Galactic Empire",   Creed = "Order and control through Imperial rule",                          Affinity = -85, TotalHolocrons = 0, IsFriendly = false },
            new global::Creeds.Web.Models.Creeds { Id = 5, CreedName = "Mandalorian Clans", Creed = "Honor, loyalty, and strength through the warrior creed",           Affinity = -55, TotalHolocrons = 0, IsFriendly = false },
            new global::Creeds.Web.Models.Creeds { Id = 6, CreedName = "Wookiee Clans",     Creed = "Loyalty, courage, and defense of Kashyyyk",                        Affinity = 30,  TotalHolocrons = 0, IsFriendly = true  },
            new global::Creeds.Web.Models.Creeds { Id = 7, CreedName = "Imperial Knights",  Creed = "The Force is a powerful tool, but always loyalty to the Emperor.", Affinity = -25, TotalHolocrons = 0, IsFriendly = false },
            new global::Creeds.Web.Models.Creeds { Id = 8, CreedName = "Jeaii Order",       Creed = "There is no light without dark. Through passion, we gain strength.", Affinity = 5, TotalHolocrons = 0, IsFriendly = true  }
        );
    }
}
