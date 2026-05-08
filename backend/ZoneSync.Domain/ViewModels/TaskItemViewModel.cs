using ZoneSync.Domain.Enums;

namespace ZoneSync.Domain.ViewModels;

public class TaskItemViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int ZoneId { get; set; }
    public string? CropName { get; set; }
    public TaskItemStatus? Status { get; set; }
    public TaskPriority? Priority { get; set; }
    public TaskType? Type { get; set; }
    public DateOnly? DueDate { get; set; }
    public string? CreatedByUserName { get; set; }
    public int AssignedUsersCount { get; set; }

    public override string ToString()
    {
        return $"{Id} :: {Name} :: {Status} :: {Priority} :: Assigned: {AssignedUsersCount}";
    }
}
