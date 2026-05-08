using ZoneSync.Domain.Models;

namespace ZoneSync.Domain.Validation;

public class AlertValidator : IModelValidator<Alert>
{
    public ValidationResult Validate(Alert alert)
    {
        ValidationResult result = new ValidationResult();

        if (alert.ZoneId <= 0)
            result.AddError("Alert must belong to a zone.");

        if (alert.CropPlanId <= 0)
            result.AddError("Alert must belong to a crop plan.");

        if (alert.Type is null)
            result.AddError("Alert type is required.");

        if (alert.Severity is null)
            result.AddError("Alert severity is required.");

        if (alert.Status is null)
            result.AddError("Alert status is required.");

        return result;
    }
}
