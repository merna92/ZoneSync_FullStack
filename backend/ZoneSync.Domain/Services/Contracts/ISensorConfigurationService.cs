using ZoneSync.Domain.Models;

namespace ZoneSync.Domain.Services.Contracts;

public interface ISensorConfigurationService
{
    ZoneConfiguration ConfigureSensor(Zone zone, SensorInstance sensorInstance, User configuredByUser, int configurationId);
}
