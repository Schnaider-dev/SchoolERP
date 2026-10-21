using System.ComponentModel.DataAnnotations;
using EduSaasBackend.Models.Enum;

namespace EduSaasBackend.Models;

public class ClassGroup
{
    public int ClassGroupId { get; set; }

    public int SchoolId { get; set; }
    public School School { get; set; } = null!;

    public int AcademicYearId { get; set; }
    public AcademicYear AcademicYear { get; set; } = null!;

    [Required, StringLength(80)]
    public string Name { get; set; } = null!;

    public SchoolGrade GradeLevel { get; set; }

    [Range(1, 500)]
    public int? Capacity { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    public ICollection<CourseOffering> CourseOfferings { get; set; } = new List<CourseOffering>();
}
