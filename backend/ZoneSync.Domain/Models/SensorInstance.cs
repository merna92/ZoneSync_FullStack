using ZoneSync.Domain.Enums;

namespace ZoneSync.Domain.Models;

public class SensorInstance
{
    public int Id { get; set; }
    public int SensorModelId { get; set; }
    public string? SerialNumber { get; set; }
    public SensorStatus? Status { get; set; }

    public SensorModel? SensorModel { get; set; }
    public List<ZoneConfiguration> ZoneConfigurations { get; set; } = [];
    public List<CheckRequirement> CheckRequirements { get; set; } = [];
    public List<SensorReading> SensorReadings { get; set; } = [];
    public List<Alert> Alerts { get; set; } = [];
}
