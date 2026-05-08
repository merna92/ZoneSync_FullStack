using ZoneSync.Domain.Enums;

namespace ZoneSync.Domain.ViewModels;

public class StageRequirementViewModel
{
    public int RequirementId { get; set; }
    public string? RequirementName { get; set; }
    public string? StageName { get; set; }
    public decimal? MinValue { get; set; }
    public decimal? MaxValue { get; set; }
    public ApplicablePeriod? ApplicablePeriod { get; set; }
    public int? DefaultVerificationHours { get; set; }

    public override string ToString()
    {
        return $"{RequirementId} :: {RequirementName} :: {MinValue} - {MaxValue}";
    }
}
