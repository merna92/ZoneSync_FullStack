using ZoneSync.Domain.Enums;

namespace ZoneSync.Domain.Models;

public class User
{
    public int UserId { get; set; }
    public string UserFirstName { get; set; } = string.Empty;
    public string UserLastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public UserRole? RoleType { get; set; }
    public string? PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public bool IsEmailVerified { get; set; }
    public DateTime? LastLogin { get; set; }
    public DateTime? SoftDeleteAt { get; set; }

    public List<Zone> CreatedZones { get; set; } = [];
    public List<Invitation> SentInvitations { get; set; } = [];
    public List<Invitation> ReceivedInvitations { get; set; } = [];
    public List<CropPlan> CreatedCropPlans { get; set; } = [];
    public List<ZoneConfiguration> ZoneConfigurations { get; set; } = [];
    public List<Alert> ConfirmedAlerts { get; set; } = [];
    public List<TaskItem> CreatedTasks { get; set; } = [];
    public List<TaskUser> AssignedTasks { get; set; } = [];
    public List<ActionLog> ActionLogs { get; set; } = [];
}
