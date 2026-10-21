using System.ComponentModel.DataAnnotations;
using EduSaasBackend.Models.Enum;

namespace EduSaasBackend.Models;

public class Assessment
{
    public int AssessmentId { get; set; }

    public int CourseOfferingId { get; set; }
    public CourseOffering CourseOffering { get; set; } = null!;

    [Required, StringLength(150)]
    public string Title { get; set; } = null!;

    public AssessmentType Type { get; set; }
    public DateTime? ScheduledAtUtc { get; set; }

    [Range(typeof(decimal), "0.01", "100000")]
    public decimal MaximumScore { get; set; } = 100;

    [StringLength(2000)]
    public string? Instructions { get; set; }

    public ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
