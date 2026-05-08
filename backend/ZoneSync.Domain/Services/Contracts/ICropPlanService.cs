using ZoneSync.Domain.Models;

namespace ZoneSync.Domain.Services.Contracts;

public interface ICropPlanService
{
    CropPlan CreateCropPlan(
        Crop crop,
        Zone zone,
        User createdByUser,
        int cropPlanId,
        DateOnly plantingDate,
        GrowthStage? currentStage = null);
}
