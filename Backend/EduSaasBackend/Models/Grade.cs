using System.ComponentModel.DataAnnotations;

namespace EduSaasBackend.Models;

public class Grade
{
    public int GradeId { get; set; }

    public int AssessmentId { get; set; }
    public Assessment Assessment { get; set; } = null!;

    public int StudentProfileId { get; set; }
    public StudentProfile Student { get; set; } = null!;

    [Range(typeof(decimal), "0", "100000")]
    public decimal Score { get; set; }

    [StringLength(2000)]
    public string? Feedback { get; set; }

    public DateTime GradedAtUtc { get; set; } = DateTime.UtcNow;
}
