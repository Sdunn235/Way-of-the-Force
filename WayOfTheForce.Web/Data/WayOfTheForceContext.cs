using Microsoft.EntityFrameworkCore;
using WayOfTheForce.Web.Models;

namespace WayOfTheForce.Web.Data;

public class WayOfTheForceContext : DbContext
{
    public WayOfTheForceContext(DbContextOptions<WayOfTheForceContext> options) : base(options)
    {
    }

    public DbSet<Creeds> Creeds => Set<Creeds>();
    public DbSet<Holocrons> Holocrons => Set<Holocrons>();

    // Seed data — the alliances that used to live in CreedsData.cs.
    // Same ids as before, so existing /Creeds/Details/{id} links still work.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Creeds>().HasData(
            new Creeds { Id = 1, CreedName = "Jedi Order",        Creed = "Peacekeepers who serve the light side of the Force",               Homeworld = "Coruscant", Affinity = 95,  TotalHolocrons = 0, IsFriendly = true  },
            new Creeds { Id = 2, CreedName = "Sith Order",        Creed = "Power through passion and mastery of the dark side",               Homeworld = "Moraband", Affinity = -95, TotalHolocrons = 0, IsFriendly = false },
            new Creeds { Id = 3, CreedName = "Rebel Alliance",    Creed = "Freedom and hope against Imperial tyranny",                        Homeworld = "Yavin 4", Affinity = 70,  TotalHolocrons = 0, IsFriendly = true  },
            new Creeds { Id = 4, CreedName = "Galactic Empire",   Creed = "Order and control through Imperial rule",                          Homeworld = "Coruscant", Affinity = -85, TotalHolocrons = 0, IsFriendly = false },
            new Creeds { Id = 5, CreedName = "Mandalorian Clans", Creed = "Honor, loyalty, and strength through the warrior creed",           Homeworld = "Mandalore", Affinity = -55, TotalHolocrons = 0, IsFriendly = false },
            new Creeds { Id = 6, CreedName = "Wookiee Clans",     Creed = "Loyalty, courage, and defense of Kashyyyk",                        Homeworld = "Kashyyyk", Affinity = 30,  TotalHolocrons = 0, IsFriendly = true  },
            new Creeds { Id = 7, CreedName = "Imperial Knights",  Creed = "The Force is a powerful tool, but always loyalty to the Emperor.", Homeworld = "Bastion", Affinity = -25, TotalHolocrons = 0, IsFriendly = false },
            new Creeds { Id = 8, CreedName = "Je'daii Order",     Creed = "There is no light without dark. Through passion, we gain strength.", Homeworld = "Tython", Affinity = 5, TotalHolocrons = 0, IsFriendly = true  }
        );

        // Holocrons from Wookieepedia, matched to the creed that made or held each one.
        // Where the source gives no creation year, the earliest year it does give is used.
        modelBuilder.Entity<Holocrons>().HasData(
            new Holocrons { Id = 1, CreedId = 1, Title = "Tedryn Holocron",           Author = "Tedryn",          WhenRecorded = 4000,  Era = GalacticEra.BBY, FoundLocation = "Dantooine" },
            new Holocrons { Id = 2, CreedId = 1, Title = "Eno Cordova's Holocron",    Author = "Jocasta Nu",      WhenRecorded = 14,    Era = GalacticEra.BBY, FoundLocation = "Bogano Vault, Bogano" },
            new Holocrons { Id = 3, CreedId = 2, Title = "Holocron of King Adas",     Author = "King Adas",       WhenRecorded = 27700, Era = GalacticEra.BBY, FoundLocation = "Korriban" },
            new Holocrons { Id = 4, CreedId = 2, Title = "Sith Holocron of Malachor", Author = "Unknown Sith",    WhenRecorded = 2,     Era = GalacticEra.BBY, FoundLocation = "Malachor Sith Temple" },
            new Holocrons { Id = 5, CreedId = 3, Title = "Kanan Jarrus's Holocron",   Author = "Depa Billaba",    WhenRecorded = 19,    Era = GalacticEra.BBY, FoundLocation = "The Ghost" },
            new Holocrons { Id = 6, CreedId = 4, Title = "Codex of Tython",           Author = "Unknown Jedi",    WhenRecorded = 1,     Era = GalacticEra.ABY, FoundLocation = "Dantooine" },
            new Holocrons { Id = 7, CreedId = 7, Title = "Eshkar Niin's Holocron",    Author = "Eshkar Niin",     WhenRecorded = 137,   Era = GalacticEra.ABY, FoundLocation = null },
            new Holocrons { Id = 8, CreedId = 8, Title = "Rajivari's Holocron",       Author = "Master Rajivari", WhenRecorded = 25783, Era = GalacticEra.BBY, FoundLocation = "Tython" }
        );
    }
}
