using ZoneSync.Domain.Enums;
using ZoneSync.Domain.Models;
using ZoneSync.Domain.Services.Contracts;

namespace ZoneSync.Domain.Services;

public class AlertService : IAlertService
{
    public Alert CreateAlert(
        CropPlan cropPlan,
        SensorInstance sensorInstance,
        int alertId,
        AlertType type,
        AlertSeverity severity,
        AlertStatus status)
    {
        Alert alert = new Alert
        {
            Id = alertId,
            ZoneId = cropPlan.ZoneId,
            Zone = cropPlan.Zone,
            CropPlanId = cropPlan.Id,
            CropPlan = cropPlan,
            SensorInstanceId = sensorInstance.Id,
            SensorInstance = sensorInstance,
            Type = type,
            Severity = severity,
            Status = status,
            FiringDate = DateTime.Now
        };

        cropPlan.Zone?.Alerts.Add(alert);
        cropPlan.Alerts.Add(alert);
        sensorInstance.Alerts.Add(alert);

        return alert;
    }
}
