namespace ZoneSync.Domain.Models;

public class CropPlan
{
    public int Id { get; set; }
    public int CropId { get; set; }
    public int ZoneId { get; set; }
    public int CreatedByUserId { get; set; }
    public int? CurrentStageId { get; set; }
    public DateOnly? PlantingDate { get; set; }
    public DateOnly? ActualHarvestTime { get; set; }
    public bool IsActive { get; set; } = true;

    public Crop? Crop { get; set; }
    public Zone? Zone { get; set; }
    public User? CreatedByUser { get; set; }
    public GrowthStage? CurrentStage { get; set; }
    public List<CheckRequirement> CheckRequirements { get; set; } = [];
    public List<Alert> Alerts { get; set; } = [];
    public List<TaskItem> Tasks { get; set; } = [];
}
