namespace ZoneSync.Domain.ViewModels;

public class FarmViewModel
{
    public int FarmId { get; set; }
    public string FarmName { get; set; } = string.Empty;
    public string? Location { get; set; }
    public string? SoilType { get; set; }
    public decimal? TotalArea { get; set; }
    public int ZonesCount { get; set; }

    public override string ToString()
    {
        return $"{FarmId} :: {FarmName} :: {Location} :: Zones: {ZonesCount}";
    }
}
