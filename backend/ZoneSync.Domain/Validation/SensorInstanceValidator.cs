using ZoneSync.Domain.Models;

namespace ZoneSync.Domain.Validation;

public class SensorInstanceValidator : IModelValidator<SensorInstance>
{
    public ValidationResult Validate(SensorInstance sensorInstance)
    {
        ValidationResult result = new ValidationResult();

        if (sensorInstance.SensorModelId <= 0)
            result.AddError("Sensor instance must have a sensor model.");

        if (!ValidationRules.IsRequired(sensorInstance.SerialNumber))
            result.AddError("Sensor serial number is required.");

        if (sensorInstance.Status is null)
            result.AddError("Sensor status is required.");

        return result;
    }
}
