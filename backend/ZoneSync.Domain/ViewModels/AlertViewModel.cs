using ZoneSync.Domain.Enums;

namespace ZoneSync.Domain.ViewModels;

public class AlertViewModel
{
    public int Id { get; set; }
    public int ZoneId { get; set; }
    public string? CropName { get; set; }
    public AlertType? Type { get; set; }
    public AlertSeverity? Severity { get; set; }
    public AlertStatus? Status { get; set; }
    public DateTime? FiringDate { get; set; }
    public string? ConfirmedByUserName { get; set; }

    public override string ToString()
    {
        return $"{Id} :: Zone {ZoneId} :: {Type} :: {Severity} :: {Status}";
    }
}
