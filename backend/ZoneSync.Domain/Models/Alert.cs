using ZoneSync.Domain.Enums;

namespace ZoneSync.Domain.Models;

public class Alert
{
    public int Id { get; set; }
    public int ZoneId { get; set; }
    public int CropPlanId { get; set; }
    public int? CheckRequirementId { get; set; }
    public int? SensorInstanceId { get; set; }
    public int? ConfirmedByUserId { get; set; }
    public AlertType? Type { get; set; }
    public DateTime? FiringDate { get; set; }
    public AlertSeverity? Severity { get; set; }
    public AlertStatus? Status { get; set; }

    public Zone? Zone { get; set; }
    public CropPlan? CropPlan { get; set; }
    public CheckRequirement? CheckRequirement { get; set; }
    public SensorInstance? SensorInstance { get; set; }
    public User? ConfirmedByUser { get; set; }
    public List<TaskItem> Tasks { get; set; } = [];
}
