using ZoneSync.Domain.Models;
using ZoneSync.Domain.Services.Contracts;

namespace ZoneSync.Domain.Services;

public class SensorConfigurationService : ISensorConfigurationService
{
    public ZoneConfiguration ConfigureSensor(Zone zone, SensorInstance sensorInstance, User configuredByUser, int configurationId)
    {
        ZoneConfiguration zoneConfiguration = new ZoneConfiguration
        {
            Id = configurationId,
            ZoneId = zone.ZoneId,
            Zone = zone,
            SensorInstanceId = sensorInstance.Id,
            SensorInstance = sensorInstance,
            ConfiguredByUserId = configuredByUser.UserId,
            ConfiguredByUser = configuredByUser
        };

        zone.ZoneConfigurations.Add(zoneConfiguration);
        sensorInstance.ZoneConfigurations.Add(zoneConfiguration);
        configuredByUser.ZoneConfigurations.Add(zoneConfiguration);

        return zoneConfiguration;
    }
}
