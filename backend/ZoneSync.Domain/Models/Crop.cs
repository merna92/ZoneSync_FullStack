using ZoneSync.Domain.Enums;

namespace ZoneSync.Domain.Models;

public class Crop
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Season? Season { get; set; }
    public string? Category { get; set; }
    public IrrigationType? IrrigationType { get; set; }

    public List<GrowthStage> GrowthStages { get; set; } = [];
    public List<CropPlan> CropPlans { get; set; } = [];
}
