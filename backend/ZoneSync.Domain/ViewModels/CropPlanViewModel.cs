namespace ZoneSync.Domain.ViewModels;

public class CropPlanViewModel
{
    public int Id { get; set; }
    public string? CropName { get; set; }
    public string? FarmName { get; set; }
    public int ZoneId { get; set; }
    public string? CurrentStageName { get; set; }
    public DateOnly? PlantingDate { get; set; }
    public DateOnly? ActualHarvestTime { get; set; }
    public bool IsActive { get; set; }

    public override string ToString()
    {
        return $"{Id} :: {CropName} :: Zone {ZoneId} :: Active: {IsActive}";
    }
}
