using System.ComponentModel.DataAnnotations;

namespace EduSaasBackend.Models;

public class CourseOffering
{
    public int CourseOfferingId { get; set; }

    public int SchoolId { get; set; }
    public int AcademicYearId { get; set; }
    public int ClassGroupId { get; set; }
    public int CourseId { get; set; }
    public int? TeacherProfileId { get; set; }

    public School School { get; set; } = null!;
    public AcademicYear AcademicYear { get; set; } = null!;
    public ClassGroup ClassGroup { get; set; } = null!;
    public Course Course { get; set; } = null!;
    public TeacherProfile? Teacher { get; set; }

    [StringLength(30)]
    public string? Section { get; set; }

    public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    public ICollection<CourseLesson> Lessons { get; set; } = new List<CourseLesson>();
    public ICollection<Assessment> Assessments { get; set; } = new List<Assessment>();
    public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
    public ICollection<AttendanceRecord> AttendanceRecords { get; set; } = new List<AttendanceRecord>();
}
