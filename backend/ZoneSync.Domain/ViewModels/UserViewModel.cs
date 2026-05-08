using ZoneSync.Domain.Enums;

namespace ZoneSync.Domain.ViewModels;

public class UserViewModel
{
    public int UserId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public UserRole? RoleType { get; set; }
    public bool IsEmailVerified { get; set; }

    public override string ToString()
    {
        return $"{UserId} :: {FullName} :: {Email} :: {RoleType}";
    }
}
