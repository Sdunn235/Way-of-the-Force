using Microsoft.EntityFrameworkCore;
using Creeds.Web.Models;

namespace Creeds.Web.Data;

public class WayOfTheForceContext : DbContext
{
    public WayOfTheForceContext(DbContextOptions<WayOfTheForceContext> options) : base(options)
    {
    }

    public DbSet<global::Creeds.Web.Models.Creeds> Creeds => Set<global::Creeds.Web.Models.Creeds>();
}
