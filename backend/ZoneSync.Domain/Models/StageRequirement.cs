using ZoneSync.Domain.Enums;

namespace ZoneSync.Domain.Models;

public class StageRequirement
{
    public int RequirementId { get; set; }
    public int StageId { get; set; }
    public string? RequirementName { get; set; }
    public decimal? MinValue { get; set; }
    public decimal? MaxValue { get; set; }
    public ApplicablePeriod? ApplicablePeriod { get; set; }
    public int? DefaultVerificationHours { get; set; }
    public bool ChosenByUser { get; set; }

    public GrowthStage? GrowthStage { get; set; }
    public List<StageRequirementMeasurementType> MeasurementTypes { get; set; } = [];
    public List<CheckRequirement> CheckRequirements { get; set; } = [];
}
