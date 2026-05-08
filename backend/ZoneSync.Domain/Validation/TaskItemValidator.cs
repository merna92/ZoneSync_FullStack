using ZoneSync.Domain.Models;

namespace ZoneSync.Domain.Validation;

public class TaskItemValidator : IModelValidator<TaskItem>
{
    public ValidationResult Validate(TaskItem task)
    {
        ValidationResult result = new ValidationResult();

        if (!ValidationRules.IsRequired(task.Name))
            result.AddError("Task name is required.");

        if (task.ZoneId <= 0)
            result.AddError("Task must belong to a zone.");

        if (task.CropPlanId <= 0)
            result.AddError("Task must belong to a crop plan.");

        if (task.CreatedByUserId <= 0)
            result.AddError("Task creator is required.");

        if (task.Status is null)
            result.AddError("Task status is required.");

        if (task.Priority is null)
            result.AddError("Task priority is required.");

        if (task.Type is null)
            result.AddError("Task type is required.");

        return result;
    }
}
