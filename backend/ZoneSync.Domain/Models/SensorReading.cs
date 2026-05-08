namespace ZoneSync.Domain.Models;

public class SensorReading
{
    public int Id { get; set; }
    public int SensorInstanceId { get; set; }
    public int MeasurementTypeId { get; set; }
    public decimal? Value { get; set; }
    public DateOnly? Date { get; set; }
    public TimeOnly? Time { get; set; }

    public SensorInstance? SensorInstance { get; set; }
    public MeasurementType? MeasurementType { get; set; }
}
