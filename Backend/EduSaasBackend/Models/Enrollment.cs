using EduSaasBackend.Models.Enum;

namespace EduSaasBackend.Models;

public class Enrollment
{
    public int EnrollmentId { get; set; }

    public int StudentProfileId { get; set; }
    public StudentProfile Student { get; set; } = null!;

    public int ClassGroupId { get; set; }
    public ClassGroup ClassGroup { get; set; } = null!;

    public DateTime EnrolledAtUtc { get; set; } = DateTime.UtcNow;
    public EnrollmentStatus Status { get; set; } = EnrollmentStatus.Active;
    public DateOnly? LeftOn { get; set; }
}
