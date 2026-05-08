using ZoneSync.Domain.Enums;

namespace ZoneSync.Domain.ViewModels;

public class ZoneViewModel
{
    public int ZoneId { get; set; }
    public decimal? ZoneArea { get; set; }
    public ZoneStatus? ZoneStatus { get; set; }
    public string? FarmName { get; set; }
    public string? CreatedByUserName { get; set; }
    public int ActiveCropPlansCount { get; set; }
    public int SensorsCount { get; set; }

    public override string ToString()
    {
        return $"{ZoneId} :: {FarmName} :: Area: {ZoneArea} :: Status: {ZoneStatus}";
    }
}
