using ZoneSync.Domain.Models;

namespace ZoneSync.Domain.Validation;

public class ZoneValidator : IModelValidator<Zone>
{
    public ValidationResult Validate(Zone zone)
    {
        ValidationResult result = new ValidationResult();

        if (zone.ZoneArea.HasValue && zone.ZoneArea <= 0)
            result.AddError("Zone area must be greater than zero.");

        if (zone.ZoneStatus is null)
            result.AddError("Zone status is required.");

        if (zone.FarmId <= 0)
            result.AddError("Zone must belong to a farm.");

        if (zone.CreatedByUserId <= 0)
            result.AddError("Zone creator is required.");

        return result;
    }
}
