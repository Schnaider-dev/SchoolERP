using System.ComponentModel.DataAnnotations;

namespace EduSaasBackend.Models;

public class CourseLesson
{
    public int CourseLessonId { get; set; }

    public int CourseOfferingId { get; set; }
    public CourseOffering CourseOffering { get; set; } = null!;

    [Required, StringLength(150)]
    public string Title { get; set; } = null!;

    [StringLength(5000)]
    public string? Description { get; set; }

    public string? Content { get; set; }

    [Url, StringLength(1000)]
    public string? VideoUrl { get; set; }

    [Range(1, int.MaxValue)]
    public int Order { get; set; }

    public DateTime? AvailableFromUtc { get; set; }
    public bool IsPublished { get; set; }
}
