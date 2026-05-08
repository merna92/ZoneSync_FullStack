using ZoneSync.Domain.Models;

namespace ZoneSync.Domain.Validation;

public class CropPlanValidator : IModelValidator<CropPlan>
{
    public ValidationResult Validate(CropPlan cropPlan)
    {
        ValidationResult result = new ValidationResult();

        if (cropPlan.CropId <= 0)
            result.AddError("Crop plan must have a crop.");

        if (cropPlan.ZoneId <= 0)
            result.AddError("Crop plan must belong to a zone.");

        if (cropPlan.CreatedByUserId <= 0)
            result.AddError("Crop plan creator is required.");

        if (cropPlan.PlantingDate.HasValue && cropPlan.ActualHarvestTime.HasValue &&
            cropPlan.ActualHarvestTime < cropPlan.PlantingDate)
            result.AddError("Actual harvest date cannot be before planting date.");

        return result;
    }
}
