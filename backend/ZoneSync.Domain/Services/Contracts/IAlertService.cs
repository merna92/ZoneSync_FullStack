using ZoneSync.Domain.Enums;
using ZoneSync.Domain.Models;

namespace ZoneSync.Domain.Services.Contracts;

public interface IAlertService
{
    Alert CreateAlert(
        CropPlan cropPlan,
        SensorInstance sensorInstance,
        int alertId,
        AlertType type,
        AlertSeverity severity,
        AlertStatus status);
}
