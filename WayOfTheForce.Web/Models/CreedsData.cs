namespace Creeds.Web.Models;

// Star Wars alliance data, hard-coded for now. In week 7 this becomes a
// database table and this file goes away — the controller barely changes.
public static class CreedsData
{
    public static List<Creeds> All { get; } = new()
    {
        new Creeds { Id = 1, CreedName = "Jedi Order",        Creed = "Peacekeepers who serve the light side of the Force", Affinity = 95, TotalHolocrons = 0, IsFriendly = true  },
        new Creeds { Id = 2, CreedName = "Sith Order",        Creed = "Power through passion and mastery of the dark side",    Affinity = -95, TotalHolocrons = 0, IsFriendly = false },
        new Creeds { Id = 3, CreedName = "Rebel Alliance",    Creed = "Freedom and hope against Imperial tyranny",             Affinity = 70, TotalHolocrons = 0, IsFriendly = true  },
        new Creeds { Id = 4, CreedName = "Galactic Empire",   Creed = "Order and control through Imperial rule",                Affinity = -85, TotalHolocrons = 0, IsFriendly = false },
        new Creeds { Id = 5, CreedName = "Mandalorian Clans", Creed = "Honor, loyalty, and strength through the warrior creed", Affinity = -55, TotalHolocrons = 0, IsFriendly = false },
        new Creeds { Id = 6, CreedName = "Wookiee Clans",     Creed = "Loyalty, courage, and defense of Kashyyyk",              Affinity = 30, TotalHolocrons = 0, IsFriendly = true  },
        new Creeds { Id = 7, CreedName = "Imperial Knights", Creed = "The Force is a powerful tool, but always loyalty to the Emperor. ", Affinity = -25, TotalHolocrons = 0, IsFriendly = false },
        new Creeds { Id = 8, CreedName = "Jeaii Order",     Creed = "There is no light without dark. Through passion, we gain strength.", Affinity = 5, TotalHolocrons = 0, IsFriendly = true  },
    };
}
