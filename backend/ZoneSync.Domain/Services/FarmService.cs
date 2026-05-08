using ZoneSync.Domain.Enums;
using ZoneSync.Domain.Models;
using ZoneSync.Domain.Services.Contracts;

namespace ZoneSync.Domain.Services;

public class FarmService : IFarmService
{
    public Zone CreateZone(Farm farm, User createdByUser, int zoneId, decimal zoneArea, ZoneStatus zoneStatus)
    {
        Zone zone = new Zone
        {
            ZoneId = zoneId,
            ZoneArea = zoneArea,
            ZoneStatus = zoneStatus,
            FarmId = farm.FarmId,
            Farm = farm,
            CreatedByUserId = createdByUser.UserId,
            CreatedByUser = createdByUser
        };

        farm.Zones.Add(zone);
        createdByUser.CreatedZones.Add(zone);

        return zone;
    }
}
