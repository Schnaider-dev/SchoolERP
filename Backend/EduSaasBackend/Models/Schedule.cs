using System.ComponentModel.DataAnnotations;

namespace EduSaasBackend.Models;

public class Schedule : IValidatableObject
{
    public int ScheduleId { get; set; }

    public int CourseOfferingId { get; set; }
    public CourseOffering CourseOffering { get; set; } = null!;

    public DayOfWeek DayOfWeek { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }

    [StringLength(40)]
    public string? Room { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (EndTime <= StartTime)
        {
            yield return new ValidationResult(
                "The schedule end time must be after its start time.",
                [nameof(EndTime), nameof(StartTime)]);
        }
    }
}
