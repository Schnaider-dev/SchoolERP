using System.ComponentModel.DataAnnotations;

namespace EduSaasBackend.Models;

public class AcademicYear : IValidatableObject
{
    public int AcademicYearId { get; set; }

    public int SchoolId { get; set; }
    public School School { get; set; } = null!;

    [Required, StringLength(30)]
    public string Name { get; set; } = null!;

    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public bool IsCurrent { get; set; }

    public ICollection<ClassGroup> Classes { get; set; } = new List<ClassGroup>();
    public ICollection<CourseOffering> CourseOfferings { get; set; } = new List<CourseOffering>();

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (EndDate <= StartDate)
        {
            yield return new ValidationResult(
                "The academic year end date must be after its start date.",
                [nameof(EndDate), nameof(StartDate)]);
        }
    }
}
