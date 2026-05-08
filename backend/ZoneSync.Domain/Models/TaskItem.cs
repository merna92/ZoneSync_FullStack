using ZoneSync.Domain.Enums;

namespace ZoneSync.Domain.Models;

public class TaskItem
{
    public int Id { get; set; }
    public int ZoneId { get; set; }
    public int CropPlanId { get; set; }
    public int? AlertId { get; set; }
    public int CreatedByUserId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public TaskItemStatus? Status { get; set; }
    public DateOnly? DueDate { get; set; }
    public DateTime? CompletionTime { get; set; }
    public TaskPriority? Priority { get; set; }
    public int? ActualVerificationHours { get; set; }
    public TaskType? Type { get; set; }

    public Zone? Zone { get; set; }
    public CropPlan? CropPlan { get; set; }
    public Alert? Alert { get; set; }
    public User? CreatedByUser { get; set; }
    public List<TaskUser> AssignedUsers { get; set; } = [];
    public List<ActionLog> ActionLogs { get; set; } = [];
}
