using ZoneSync.Domain.Enums;

namespace ZoneSync.Domain.ViewModels;

public class SensorInstanceViewModel
{
    public int Id { get; set; }
    public string? SerialNumber { get; set; }
    public SensorStatus? Status { get; set; }
    public string? SensorModelName { get; set; }
    public string? SensorType { get; set; }

    public override string ToString()
    {
        return $"{Id} :: {SensorModelName} :: {SerialNumber} :: {Status}";
    }
}
