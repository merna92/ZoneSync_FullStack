namespace ZoneSync.Domain.Models;

public class GrowthStage
{
    public int StageId { get; set; }
    public int CropId { get; set; }
    public string? StageName { get; set; }
    public int? StageOrder { get; set; }
    public int? StageDuration { get; set; }

    public Crop? Crop { get; set; }
    public List<StageRequirement> StageRequirements { get; set; } = [];
    public List<CropPlan> CurrentCropPlans { get; set; } = [];
}
