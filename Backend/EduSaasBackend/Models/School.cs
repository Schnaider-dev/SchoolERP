using System.ComponentModel.DataAnnotations;

namespace EduSaasBackend.Models;

public class School
{
    public int SchoolId { get; set; }

    [Required, StringLength(160)]
    public string SchoolName { get; set; } = null!;

    [StringLength(30)]
    public string? PhoneNumber { get; set; }

    [EmailAddress, StringLength(254)]
    public string? Email { get; set; }

    [Url, StringLength(300)]
    public string? Website { get; set; }

    public Address Address { get; set; } = new();

    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

    public ICollection<SchoolMembership> Memberships { get; set; } = new List<SchoolMembership>();
    public ICollection<AcademicYear> AcademicYears { get; set; } = new List<AcademicYear>();
    public ICollection<ClassGroup> Classes { get; set; } = new List<ClassGroup>();
    public ICollection<Course> Courses { get; set; } = new List<Course>();
    public ICollection<CourseOffering> CourseOfferings { get; set; } = new List<CourseOffering>();
}
