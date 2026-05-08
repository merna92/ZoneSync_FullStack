namespace ZoneSync.Domain.Models;

public class CheckRequirement
{
    public int CheckId { get; set; }
    public int PlanId { get; set; }
    public int ZoneId { get; set; }
    public int RequirementId { get; set; }
    public int? SensorInstanceId { get; set; }
    public decimal? CheckedValue { get; set; }
    public DateTime? LastCheckedDate { get; set; }
    public bool? IsSatisfied { get; set; }

    public CropPlan? CropPlan { get; set; }
    public Zone? Zone { get; set; }
    public StageRequirement? StageRequirement { get; set; }
    public SensorInstance? SensorInstance { get; set; }
    public List<Alert> Alerts { get; set; } = [];
}
