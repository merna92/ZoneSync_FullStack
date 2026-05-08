using ZoneSync.Domain.Enums;

namespace ZoneSync.Domain.Models;

public class Invitation
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? InvitedEmail { get; set; }
    public string? InvitedPhone { get; set; }
    public string? InvitationToken { get; set; }
    public string? VerificationCode { get; set; }
    public InvitationStatus? Status { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? ExpiredAt { get; set; }
    public DateTime? AcceptedAt { get; set; }
    public int SentByUserId { get; set; }
    public int? ReceivedByUserId { get; set; }
    public int? FarmId { get; set; }
    public int? ZoneId { get; set; }

    public User? SentByUser { get; set; }
    public User? ReceivedByUser { get; set; }
    public Farm? Farm { get; set; }
    public Zone? Zone { get; set; }
}
