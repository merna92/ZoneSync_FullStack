namespace ZoneSync.Domain.Models;

public class Farm
{
    public int FarmId { get; set; }
    public string FarmName { get; set; } = string.Empty;
    public string? Location { get; set; }
    public string? SoilType { get; set; }
    public decimal? TotalArea { get; set; }

    public List<Zone> Zones { get; set; } = [];
    public List<Invitation> Invitations { get; set; } = [];
}
