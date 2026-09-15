namespace Creeds.Web.Models;

public class Creeds
{
    public int Id { get; set; }
    public string CreedName { get; set; } = "";
    public string Creed { get; set; } = "";
    public int Affinity { get; set; }
    public int TotalHolocrons { get; set; }
    public bool IsFriendly { get; set; }
}
