using EduSaasBackend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EduSaasBackend.Data;

public abstract class ApplicationDbContext(DbContextOptions options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<School> Schools => Set<School>();
    public DbSet<SchoolMembership> SchoolMemberships => Set<SchoolMembership>();
    public DbSet<StudentProfile> StudentProfiles => Set<StudentProfile>();
    public DbSet<TeacherProfile> TeacherProfiles => Set<TeacherProfile>();
    public DbSet<GuardianProfile> GuardianProfiles => Set<GuardianProfile>();
    public DbSet<StudentGuardian> StudentGuardians => Set<StudentGuardian>();
    public DbSet<AcademicYear> AcademicYears => Set<AcademicYear>();
    public DbSet<ClassGroup> ClassGroups => Set<ClassGroup>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<CourseOffering> CourseOfferings => Set<CourseOffering>();
    public DbSet<CourseLesson> CourseLessons => Set<CourseLesson>();
    public DbSet<Schedule> Schedules => Set<Schedule>();
    public DbSet<Assessment> Assessments => Set<Assessment>();
    public DbSet<Grade> Grades => Set<Grade>();
    public DbSet<Assignment> Assignments => Set<Assignment>();
    public DbSet<AssignmentSubmission> AssignmentSubmissions => Set<AssignmentSubmission>();
    public DbSet<AttendanceRecord> AttendanceRecords => Set<AttendanceRecord>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<School>().OwnsOne(school => school.Address);

        builder.Entity<SchoolMembership>()
            .HasIndex(membership => new { membership.SchoolId, membership.UserId, membership.Role })
            .IsUnique();
        builder.Entity<SchoolMembership>()
            .HasOne(membership => membership.School)
            .WithMany(school => school.Memberships)
            .HasForeignKey(membership => membership.SchoolId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<SchoolMembership>()
            .HasOne(membership => membership.User)
            .WithMany(user => user.SchoolMemberships)
            .HasForeignKey(membership => membership.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<StudentProfile>()
            .HasOne(profile => profile.SchoolMembership)
            .WithOne()
            .HasForeignKey<StudentProfile>(profile => profile.SchoolMembershipId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<TeacherProfile>()
            .HasOne(profile => profile.SchoolMembership)
            .WithOne()
            .HasForeignKey<TeacherProfile>(profile => profile.SchoolMembershipId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<GuardianProfile>()
            .HasOne(profile => profile.SchoolMembership)
            .WithOne()
            .HasForeignKey<GuardianProfile>(profile => profile.SchoolMembershipId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<StudentGuardian>()
            .HasIndex(link => new { link.StudentProfileId, link.GuardianProfileId })
            .IsUnique();
        builder.Entity<StudentGuardian>()
            .HasOne(link => link.Student)
            .WithMany(student => student.Guardians)
            .HasForeignKey(link => link.StudentProfileId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<StudentGuardian>()
            .HasOne(link => link.Guardian)
            .WithMany(guardian => guardian.StudentRelationships)
            .HasForeignKey(link => link.GuardianProfileId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<AcademicYear>()
            .HasIndex(year => new { year.SchoolId, year.Name })
            .IsUnique();
        builder.Entity<ClassGroup>()
            .HasIndex(classGroup => new { classGroup.AcademicYearId, classGroup.Name })
            .IsUnique();
        builder.Entity<ClassGroup>()
            .HasOne(classGroup => classGroup.AcademicYear)
            .WithMany(year => year.Classes)
            .HasForeignKey(classGroup => classGroup.AcademicYearId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<Course>()
            .HasIndex(course => new { course.SchoolId, course.CourseCode })
            .IsUnique();

        builder.Entity<CourseOffering>()
            .HasOne(offering => offering.School)
            .WithMany(school => school.CourseOfferings)
            .HasForeignKey(offering => offering.SchoolId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<CourseOffering>()
            .HasOne(offering => offering.Teacher)
            .WithMany(teacher => teacher.CourseOfferings)
            .HasForeignKey(offering => offering.TeacherProfileId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<CourseOffering>()
            .HasOne(offering => offering.ClassGroup)
            .WithMany(classGroup => classGroup.CourseOfferings)
            .HasForeignKey(offering => offering.ClassGroupId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<CourseOffering>()
            .HasIndex(offering => new
            {
                offering.AcademicYearId,
                offering.ClassGroupId,
                offering.CourseId,
                offering.Section
            })
            .IsUnique();
        builder.Entity<CourseLesson>()
            .HasIndex(lesson => new { lesson.CourseOfferingId, lesson.Order })
            .IsUnique();

        builder.Entity<Enrollment>()
            .HasIndex(enrollment => new { enrollment.StudentProfileId, enrollment.ClassGroupId })
            .IsUnique();
        builder.Entity<Enrollment>()
            .HasOne(enrollment => enrollment.Student)
            .WithMany(student => student.Enrollments)
            .HasForeignKey(enrollment => enrollment.StudentProfileId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<Enrollment>()
            .HasOne(enrollment => enrollment.ClassGroup)
            .WithMany(classGroup => classGroup.Enrollments)
            .HasForeignKey(enrollment => enrollment.ClassGroupId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Grade>()
            .HasIndex(grade => new { grade.AssessmentId, grade.StudentProfileId })
            .IsUnique();
        builder.Entity<Grade>()
            .HasOne(grade => grade.Student)
            .WithMany(student => student.Grades)
            .HasForeignKey(grade => grade.StudentProfileId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<AssignmentSubmission>()
            .HasIndex(submission => new { submission.AssignmentId, submission.StudentProfileId })
            .IsUnique();
        builder.Entity<AssignmentSubmission>()
            .HasOne(submission => submission.Student)
            .WithMany(student => student.AssignmentSubmissions)
            .HasForeignKey(submission => submission.StudentProfileId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<AttendanceRecord>()
            .HasIndex(record => new { record.CourseOfferingId, record.StudentProfileId, record.AttendanceDate })
            .IsUnique();
        builder.Entity<AttendanceRecord>()
            .HasOne(record => record.Student)
            .WithMany(student => student.AttendanceRecords)
            .HasForeignKey(record => record.StudentProfileId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
