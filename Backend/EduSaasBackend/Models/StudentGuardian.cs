using System.ComponentModel.DataAnnotations;

namespace EduSaasBackend.Models;

public class StudentGuardian
{
    public int StudentGuardianId { get; set; }

    public int StudentProfileId { get; set; }
    public StudentProfile Student { get; set; } = null!;

    public int GuardianProfileId { get; set; }
    public GuardianProfile Guardian { get; set; } = null!;

    [StringLength(40)]
    public string? Relationship { get; set; }

    public bool IsPrimaryContact { get; set; }
    public bool CanCollectStudent { get; set; }
}
