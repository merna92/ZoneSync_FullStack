namespace ZoneSync.Domain.Models;

public class SensorModel
{
    public int Id { get; set; }
    public string? Type { get; set; }
    public string? ModelName { get; set; }
    public string? OutputType { get; set; }

    public List<SensorModelMeasurementType> MeasurementTypes { get; set; } = [];
    public List<SensorInstance> SensorInstances { get; set; } = [];
}
