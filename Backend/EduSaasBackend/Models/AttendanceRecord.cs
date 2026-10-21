using System.ComponentModel.DataAnnotations;
using EduSaasBackend.Models.Enum;

namespace EduSaasBackend.Models;

public class AttendanceRecord
{
    public int AttendanceRecordId { get; set; }

    public int CourseOfferingId { get; set; }
    public CourseOffering CourseOffering { get; set; } = null!;

    public int StudentProfileId { get; set; }
    public StudentProfile Student { get; set; } = null!;

    public DateOnly AttendanceDate { get; set; }
    public AttendanceStatus Status { get; set; }

    [StringLength(500)]
    public string? Note { get; set; }
}
