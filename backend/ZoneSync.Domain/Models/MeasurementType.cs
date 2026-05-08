namespace ZoneSync.Domain.Models;

public class MeasurementType
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Unit { get; set; }

    public List<SensorModelMeasurementType> SensorModels { get; set; } = [];
    public List<StageRequirementMeasurementType> StageRequirements { get; set; } = [];
    public List<SensorReading> SensorReadings { get; set; } = [];
}
