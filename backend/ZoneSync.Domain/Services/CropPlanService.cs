using ZoneSync.Domain.Models;
using ZoneSync.Domain.Services.Contracts;

namespace ZoneSync.Domain.Services;

public class CropPlanService : ICropPlanService
{
    public CropPlan CreateCropPlan(
        Crop crop,
        Zone zone,
        User createdByUser,
        int cropPlanId,
        DateOnly plantingDate,
        GrowthStage? currentStage = null)
    {
        CropPlan cropPlan = new CropPlan
        {
            Id = cropPlanId,
            CropId = crop.Id,
            Crop = crop,
            ZoneId = zone.ZoneId,
            Zone = zone,
            CreatedByUserId = createdByUser.UserId,
            CreatedByUser = createdByUser,
            CurrentStageId = currentStage?.StageId,
            CurrentStage = currentStage,
            PlantingDate = plantingDate,
            IsActive = true
        };

        zone.CropPlans.Add(cropPlan);
        crop.CropPlans.Add(cropPlan);
        createdByUser.CreatedCropPlans.Add(cropPlan);
        currentStage?.CurrentCropPlans.Add(cropPlan);

        return cropPlan;
    }
}
