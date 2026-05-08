using ZoneSync.Domain.Models;

namespace ZoneSync.Domain.Validation;

public class FarmValidator : IModelValidator<Farm>
{
    public ValidationResult Validate(Farm farm)
    {
        ValidationResult result = new ValidationResult();

        if (!ValidationRules.IsRequired(farm.FarmName))
            result.AddError("Farm name is required.");

        if (farm.TotalArea.HasValue && farm.TotalArea <= 0)
            result.AddError("Farm total area must be greater than zero.");

        return result;
    }
}
