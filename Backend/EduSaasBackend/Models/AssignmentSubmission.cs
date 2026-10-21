using System.ComponentModel.DataAnnotations;
using EduSaasBackend.Models.Enum;

namespace EduSaasBackend.Models;

public class AssignmentSubmission
{
    public int AssignmentSubmissionId { get; set; }

    public int AssignmentId { get; set; }
    public Assignment Assignment { get; set; } = null!;

    public int StudentProfileId { get; set; }
    public StudentProfile Student { get; set; } = null!;

    public DateTime? SubmittedAtUtc { get; set; }
    public SubmissionStatus Status { get; set; } = SubmissionStatus.NotSubmitted;

    [StringLength(10000)]
    public string? TextResponse { get; set; }

    [Url, StringLength(1000)]
    public string? AttachmentUrl { get; set; }

    public decimal? Score { get; set; }

    [StringLength(2000)]
    public string? Feedback { get; set; }
}
