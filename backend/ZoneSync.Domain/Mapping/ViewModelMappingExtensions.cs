using ZoneSync.Domain.Models;
using ZoneSync.Domain.ViewModels;

namespace ZoneSync.Domain.Mapping;

public static class ViewModelMappingExtensions
{
    public static UserViewModel ToViewModel(this User user)
    {
        return new UserViewModel
        {
            UserId = user.UserId,
            FullName = $"{user.UserFirstName} {user.UserLastName}".Trim(),
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            RoleType = user.RoleType,
            IsEmailVerified = user.IsEmailVerified
        };
    }

    public static FarmViewModel ToViewModel(this Farm farm)
    {
        return new FarmViewModel
        {
            FarmId = farm.FarmId,
            FarmName = farm.FarmName,
            Location = farm.Location,
            SoilType = farm.SoilType,
            TotalArea = farm.TotalArea,
            ZonesCount = farm.Zones.Count
        };
    }

    public static ZoneViewModel ToViewModel(this Zone zone)
    {
        return new ZoneViewModel
        {
            ZoneId = zone.ZoneId,
            ZoneArea = zone.ZoneArea,
            ZoneStatus = zone.ZoneStatus,
            FarmName = zone.Farm?.FarmName,
            CreatedByUserName = GetUserFullName(zone.CreatedByUser),
            ActiveCropPlansCount = zone.CropPlans.Count(plan => plan.IsActive),
            SensorsCount = zone.ZoneConfigurations.Count
        };
    }

    public static CropViewModel ToViewModel(this Crop crop)
    {
        return new CropViewModel
        {
            Id = crop.Id,
            Name = crop.Name,
            Season = crop.Season,
            Category = crop.Category,
            IrrigationType = crop.IrrigationType,
            GrowthStagesCount = crop.GrowthStages.Count
        };
    }

    public static CropPlanViewModel ToViewModel(this CropPlan cropPlan)
    {
        return new CropPlanViewModel
        {
            Id = cropPlan.Id,
            CropName = cropPlan.Crop?.Name,
            FarmName = cropPlan.Zone?.Farm?.FarmName,
            ZoneId = cropPlan.ZoneId,
            CurrentStageName = cropPlan.CurrentStage?.StageName,
            PlantingDate = cropPlan.PlantingDate,
            ActualHarvestTime = cropPlan.ActualHarvestTime,
            IsActive = cropPlan.IsActive
        };
    }

    public static SensorInstanceViewModel ToViewModel(this SensorInstance sensorInstance)
    {
        return new SensorInstanceViewModel
        {
            Id = sensorInstance.Id,
            SerialNumber = sensorInstance.SerialNumber,
            Status = sensorInstance.Status,
            SensorModelName = sensorInstance.SensorModel?.ModelName,
            SensorType = sensorInstance.SensorModel?.Type
        };
    }

    public static AlertViewModel ToViewModel(this Alert alert)
    {
        return new AlertViewModel
        {
            Id = alert.Id,
            ZoneId = alert.ZoneId,
            CropName = alert.CropPlan?.Crop?.Name,
            Type = alert.Type,
            Severity = alert.Severity,
            Status = alert.Status,
            FiringDate = alert.FiringDate,
            ConfirmedByUserName = GetUserFullName(alert.ConfirmedByUser)
        };
    }

    public static TaskItemViewModel ToViewModel(this TaskItem task)
    {
        return new TaskItemViewModel
        {
            Id = task.Id,
            Name = task.Name,
            Description = task.Description,
            ZoneId = task.ZoneId,
            CropName = task.CropPlan?.Crop?.Name,
            Status = task.Status,
            Priority = task.Priority,
            Type = task.Type,
            DueDate = task.DueDate,
            CreatedByUserName = GetUserFullName(task.CreatedByUser),
            AssignedUsersCount = task.AssignedUsers.Count
        };
    }

    public static StageRequirementViewModel ToViewModel(this StageRequirement requirement)
    {
        return new StageRequirementViewModel
        {
            RequirementId = requirement.RequirementId,
            RequirementName = requirement.RequirementName,
            StageName = requirement.GrowthStage?.StageName,
            MinValue = requirement.MinValue,
            MaxValue = requirement.MaxValue,
            ApplicablePeriod = requirement.ApplicablePeriod,
            DefaultVerificationHours = requirement.DefaultVerificationHours
        };
    }

    public static ActionLogViewModel ToViewModel(this ActionLog actionLog)
    {
        return new ActionLogViewModel
        {
            Id = actionLog.Id,
            TaskName = actionLog.Task?.Name,
            ExecutedByUserName = GetUserFullName(actionLog.ExecutedByUser),
            Quantity = actionLog.Quantity,
            ExecutedAt = actionLog.ExecutedAt,
            Result = actionLog.Result,
            Notes = actionLog.Notes
        };
    }

    private static string? GetUserFullName(User? user)
    {
        if (user is null)
            return null;

        return $"{user.UserFirstName} {user.UserLastName}".Trim();
    }
}
