using System.ComponentModel.DataAnnotations;

namespace EduSaasBackend.Models;

public class Course
{
    public int CourseId { get; set; }

    public int SchoolId { get; set; }
    public School School { get; set; } = null!;

    [Required, StringLength(20)]
    public string CourseCode { get; set; } = null!;

    [Required, StringLength(120)]
    public string CourseName { get; set; } = null!;

    [StringLength(1000)]
    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<CourseOffering> Offerings { get; set; } = new List<CourseOffering>();
}
