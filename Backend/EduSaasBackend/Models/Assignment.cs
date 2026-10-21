using System.ComponentModel.DataAnnotations;

namespace EduSaasBackend.Models;

public class Assignment
{
    public int AssignmentId { get; set; }

    public int CourseOfferingId { get; set; }
    public CourseOffering CourseOffering { get; set; } = null!;

    [Required, StringLength(150)]
    public string Title { get; set; } = null!;

    [StringLength(5000)]
    public string? Instructions { get; set; }

    public DateTime? DueAtUtc { get; set; }

    [Range(typeof(decimal), "0.01", "100000")]
    public decimal? MaximumScore { get; set; }

    public bool IsPublished { get; set; }
    public ICollection<AssignmentSubmission> Submissions { get; set; } = new List<AssignmentSubmission>();
}
