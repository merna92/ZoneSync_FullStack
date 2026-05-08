using ZoneSync.Domain.Enums;

namespace ZoneSync.Domain.Models;

public class Zone
{
    public int ZoneId { get; set; }
    public decimal? ZoneArea { get; set; }
    public ZoneStatus? ZoneStatus { get; set; }
    public int FarmId { get; set; }
    public int CreatedByUserId { get; set; }

    public Farm? Farm { get; set; }
    public User? CreatedByUser { get; set; }
    public List<Invitation> Invitations { get; set; } = [];
    public List<CropPlan> CropPlans { get; set; } = [];
    public List<ZoneConfiguration> ZoneConfigurations { get; set; } = [];
    public List<CheckRequirement> CheckRequirements { get; set; } = [];
    public List<Alert> Alerts { get; set; } = [];
    public List<TaskItem> Tasks { get; set; } = [];
}
