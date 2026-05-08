using ZoneSync.Domain.Models;

namespace ZoneSync.Domain.Validation;

public class CropValidator : IModelValidator<Crop>
{
    public ValidationResult Validate(Crop crop)
    {
        ValidationResult result = new ValidationResult();

        if (!ValidationRules.IsRequired(crop.Name))
            result.AddError("Crop name is required.");

        if (crop.Season is null)
            result.AddError("Crop season is required.");

        if (crop.IrrigationType is null)
            result.AddError("Crop irrigation type is required.");

        return result;
    }
}
