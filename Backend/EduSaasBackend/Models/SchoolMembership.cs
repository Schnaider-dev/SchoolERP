using System.ComponentModel.DataAnnotations;
using EduSaasBackend.Models.Enum;

namespace EduSaasBackend.Models;

public class SchoolMembership
{
    public int SchoolMembershipId { get; set; }

    public int SchoolId { get; set; }
    public School School { get; set; } = null!;

    [Required]
    public string UserId { get; set; } = null!;
    public ApplicationUser User { get; set; } = null!;

    public SchoolRole Role { get; set; }
    public DateTime JoinedAtUtc { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;

}
