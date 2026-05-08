namespace ZoneSync.Domain.Models;

public class TaskUser
{
    public int TaskId { get; set; }
    public int UserId { get; set; }
    public DateTime AssignedAt { get; set; } = DateTime.Now;

    public TaskItem? Task { get; set; }
    public User? User { get; set; }
}
