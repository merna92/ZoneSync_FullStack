namespace ZoneSync.Domain.Models;

public class ActionLog
{
    public int Id { get; set; }
    public int TaskId { get; set; }
    public int ExecutedByUserId { get; set; }
    public decimal? Quantity { get; set; }
    public DateTime ExecutedAt { get; set; } = DateTime.Now;
    public string? Result { get; set; }
    public string? Notes { get; set; }

    public TaskItem? Task { get; set; }
    public User? ExecutedByUser { get; set; }
}
