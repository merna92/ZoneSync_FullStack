using ZoneSync.Domain.Models;
using ZoneSync.Domain.Repositories.Contracts;

namespace ZoneSync.Domain.Repositories;

public class ZoneSyncMemoryStore
{
    public IRepository<User> Users { get; set; } = new InMemoryRepository<User>();
    public IRepository<Farm> Farms { get; set; } = new InMemoryRepository<Farm>();
    public IRepository<Zone> Zones { get; set; } = new InMemoryRepository<Zone>();
    public IRepository<Crop> Crops { get; set; } = new InMemoryRepository<Crop>();
    public IRepository<CropPlan> CropPlans { get; set; } = new InMemoryRepository<CropPlan>();
    public IRepository<SensorModel> SensorModels { get; set; } = new InMemoryRepository<SensorModel>();
    public IRepository<SensorInstance> SensorInstances { get; set; } = new InMemoryRepository<SensorInstance>();
    public IRepository<Alert> Alerts { get; set; } = new InMemoryRepository<Alert>();
    public IRepository<TaskItem> Tasks { get; set; } = new InMemoryRepository<TaskItem>();
}
