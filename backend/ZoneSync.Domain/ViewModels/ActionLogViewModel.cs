namespace ZoneSync.Domain.ViewModels;

public class ActionLogViewModel
{
    public int Id { get; set; }
    public string? TaskName { get; set; }
    public string? ExecutedByUserName { get; set; }
    public decimal? Quantity { get; set; }
    public DateTime ExecutedAt { get; set; }
    public string? Result { get; set; }
    public string? Notes { get; set; }

    public override string ToString()
    {
        return $"{Id} :: {TaskName} :: {ExecutedByUserName} :: {ExecutedAt}";
    }
}
