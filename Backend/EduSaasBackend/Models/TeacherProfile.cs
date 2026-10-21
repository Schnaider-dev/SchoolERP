using System.ComponentModel.DataAnnotations;

namespace EduSaasBackend.Models;

public class TeacherProfile
{
    public int TeacherProfileId { get; set; }

    public int SchoolMembershipId { get; set; }
    public SchoolMembership SchoolMembership { get; set; } = null!;

    [StringLength(40)]
    public string? EmployeeNumber { get; set; }

    public DateOnly? HireDate { get; set; }

    [StringLength(2000)]
    public string? Qualifications { get; set; }

    public ICollection<CourseOffering> CourseOfferings { get; set; } = new List<CourseOffering>();
}
