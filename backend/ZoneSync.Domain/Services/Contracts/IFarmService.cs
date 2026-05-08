using ZoneSync.Domain.Enums;
using ZoneSync.Domain.Models;

namespace ZoneSync.Domain.Services.Contracts;

public interface IFarmService
{
    Zone CreateZone(Farm farm, User createdByUser, int zoneId, decimal zoneArea, ZoneStatus zoneStatus);
}
