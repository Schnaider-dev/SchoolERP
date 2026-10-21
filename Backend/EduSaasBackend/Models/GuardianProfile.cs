using System.ComponentModel.DataAnnotations;

namespace EduSaasBackend.Models;

public class GuardianProfile
{
    public int GuardianProfileId { get; set; }

    public int SchoolMembershipId { get; set; }
    public SchoolMembership SchoolMembership { get; set; } = null!;

    [StringLength(80)]
    public string? Employer { get; set; }

    public ICollection<StudentGuardian> StudentRelationships { get; set; } = new List<StudentGuardian>();
}
