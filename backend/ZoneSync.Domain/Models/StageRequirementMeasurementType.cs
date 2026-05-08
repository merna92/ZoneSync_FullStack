namespace ZoneSync.Domain.Models;

public class StageRequirementMeasurementType
{
    public int RequirementId { get; set; }
    public int MeasurementTypeId { get; set; }

    public StageRequirement? StageRequirement { get; set; }
    public MeasurementType? MeasurementType { get; set; }
}
