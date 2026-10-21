using System.ComponentModel.DataAnnotations;

namespace EduSaasBackend.Models;

public class StudentProfile
{
    public int StudentProfileId { get; set; }

    public int SchoolMembershipId { get; set; }
    public SchoolMembership SchoolMembership { get; set; } = null!;

    [Required, StringLength(40)]
    public string StudentNumber { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    public ICollection<StudentGuardian> Guardians { get; set; } = new List<StudentGuardian>();
    public ICollection<Grade> Grades { get; set; } = new List<Grade>();
    public ICollection<AssignmentSubmission> AssignmentSubmissions { get; set; } = new List<AssignmentSubmission>();
    public ICollection<AttendanceRecord> AttendanceRecords { get; set; } = new List<AttendanceRecord>();
}
