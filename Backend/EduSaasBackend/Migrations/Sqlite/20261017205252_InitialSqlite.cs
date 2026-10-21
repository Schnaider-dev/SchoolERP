using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduSaasBackend.Migrations.Sqlite
{
    /// <inheritdoc />
    public partial class InitialSqlite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    SchoolId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SchoolName = table.Column<string>(type: "TEXT", maxLength: 160, nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 254, nullable: true),
                    Website = table.Column<string>(type: "TEXT", maxLength: 300, nullable: true),
                    Address_Country = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Address_City = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Address_Municipality = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Address_StreetAddress = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    Address_PostalCode = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Address_MorePrecision = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.SchoolId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AcademicYears",
                columns: table => new
                {
                    AcademicYearId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SchoolId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    StartDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    IsCurrent = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicYears", x => x.AcademicYearId);
                    table.ForeignKey(
                        name: "FK_AcademicYears_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SchoolId = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseCode = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    CourseName = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolMemberships",
                columns: table => new
                {
                    SchoolMembershipId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SchoolId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false),
                    JoinedAtUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolMemberships", x => x.SchoolMembershipId);
                    table.ForeignKey(
                        name: "FK_SchoolMemberships_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SchoolMemberships_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassGroups",
                columns: table => new
                {
                    ClassGroupId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SchoolId = table.Column<int>(type: "INTEGER", nullable: false),
                    AcademicYearId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    GradeLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassGroups", x => x.ClassGroupId);
                    table.ForeignKey(
                        name: "FK_ClassGroups_AcademicYears_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYears",
                        principalColumn: "AcademicYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassGroups_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentProfiles",
                columns: table => new
                {
                    StudentProfileId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SchoolMembershipId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentNumber = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentProfiles", x => x.StudentProfileId);
                    table.ForeignKey(
                        name: "FK_StudentProfiles_SchoolMemberships_SchoolMembershipId",
                        column: x => x.SchoolMembershipId,
                        principalTable: "SchoolMemberships",
                        principalColumn: "SchoolMembershipId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherProfiles",
                columns: table => new
                {
                    TeacherProfileId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SchoolMembershipId = table.Column<int>(type: "INTEGER", nullable: false),
                    EmployeeNumber = table.Column<string>(type: "TEXT", maxLength: 40, nullable: true),
                    HireDate = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    Qualifications = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherProfiles", x => x.TeacherProfileId);
                    table.ForeignKey(
                        name: "FK_TeacherProfiles_SchoolMemberships_SchoolMembershipId",
                        column: x => x.SchoolMembershipId,
                        principalTable: "SchoolMemberships",
                        principalColumn: "SchoolMembershipId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseOfferings",
                columns: table => new
                {
                    CourseOfferingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SchoolId = table.Column<int>(type: "INTEGER", nullable: false),
                    AcademicYearId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClassGroupId = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherMembershipId = table.Column<int>(type: "INTEGER", nullable: true),
                    Section = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseOfferings", x => x.CourseOfferingId);
                    table.ForeignKey(
                        name: "FK_CourseOfferings_AcademicYears_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYears",
                        principalColumn: "AcademicYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseOfferings_ClassGroups_ClassGroupId",
                        column: x => x.ClassGroupId,
                        principalTable: "ClassGroups",
                        principalColumn: "ClassGroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseOfferings_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseOfferings_SchoolMemberships_TeacherMembershipId",
                        column: x => x.TeacherMembershipId,
                        principalTable: "SchoolMemberships",
                        principalColumn: "SchoolMembershipId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseOfferings_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentProfileId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClassGroupId = table.Column<int>(type: "INTEGER", nullable: false),
                    EnrolledAtUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    LeftOn = table.Column<DateOnly>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_Enrollments_ClassGroups_ClassGroupId",
                        column: x => x.ClassGroupId,
                        principalTable: "ClassGroups",
                        principalColumn: "ClassGroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrollments_StudentProfiles_StudentProfileId",
                        column: x => x.StudentProfileId,
                        principalTable: "StudentProfiles",
                        principalColumn: "StudentProfileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentGuardians",
                columns: table => new
                {
                    StudentGuardianId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentProfileId = table.Column<int>(type: "INTEGER", nullable: false),
                    GuardianMembershipId = table.Column<int>(type: "INTEGER", nullable: false),
                    Relationship = table.Column<string>(type: "TEXT", maxLength: 40, nullable: true),
                    IsPrimaryContact = table.Column<bool>(type: "INTEGER", nullable: false),
                    CanCollectStudent = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGuardians", x => x.StudentGuardianId);
                    table.ForeignKey(
                        name: "FK_StudentGuardians_SchoolMemberships_GuardianMembershipId",
                        column: x => x.GuardianMembershipId,
                        principalTable: "SchoolMemberships",
                        principalColumn: "SchoolMembershipId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentGuardians_StudentProfiles_StudentProfileId",
                        column: x => x.StudentProfileId,
                        principalTable: "StudentProfiles",
                        principalColumn: "StudentProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assessments",
                columns: table => new
                {
                    AssessmentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseOfferingId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    ScheduledAtUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MaximumScore = table.Column<decimal>(type: "TEXT", nullable: false),
                    Instructions = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessments", x => x.AssessmentId);
                    table.ForeignKey(
                        name: "FK_Assessments_CourseOfferings_CourseOfferingId",
                        column: x => x.CourseOfferingId,
                        principalTable: "CourseOfferings",
                        principalColumn: "CourseOfferingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseOfferingId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Instructions = table.Column<string>(type: "TEXT", maxLength: 5000, nullable: true),
                    DueAtUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MaximumScore = table.Column<decimal>(type: "TEXT", nullable: true),
                    IsPublished = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_Assignments_CourseOfferings_CourseOfferingId",
                        column: x => x.CourseOfferingId,
                        principalTable: "CourseOfferings",
                        principalColumn: "CourseOfferingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceRecords",
                columns: table => new
                {
                    AttendanceRecordId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseOfferingId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentMembershipId = table.Column<int>(type: "INTEGER", nullable: false),
                    AttendanceDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Note = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceRecords", x => x.AttendanceRecordId);
                    table.ForeignKey(
                        name: "FK_AttendanceRecords_CourseOfferings_CourseOfferingId",
                        column: x => x.CourseOfferingId,
                        principalTable: "CourseOfferings",
                        principalColumn: "CourseOfferingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendanceRecords_SchoolMemberships_StudentMembershipId",
                        column: x => x.StudentMembershipId,
                        principalTable: "SchoolMemberships",
                        principalColumn: "SchoolMembershipId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseLessons",
                columns: table => new
                {
                    CourseLessonId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseOfferingId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 5000, nullable: true),
                    Content = table.Column<string>(type: "TEXT", nullable: true),
                    VideoUrl = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    AvailableFromUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsPublished = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLessons", x => x.CourseLessonId);
                    table.ForeignKey(
                        name: "FK_CourseLessons_CourseOfferings_CourseOfferingId",
                        column: x => x.CourseOfferingId,
                        principalTable: "CourseOfferings",
                        principalColumn: "CourseOfferingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseOfferingId = table.Column<int>(type: "INTEGER", nullable: false),
                    DayOfWeek = table.Column<int>(type: "INTEGER", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    Room = table.Column<string>(type: "TEXT", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedules_CourseOfferings_CourseOfferingId",
                        column: x => x.CourseOfferingId,
                        principalTable: "CourseOfferings",
                        principalColumn: "CourseOfferingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssessmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentMembershipId = table.Column<int>(type: "INTEGER", nullable: false),
                    Score = table.Column<decimal>(type: "TEXT", nullable: false),
                    Feedback = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    GradedAtUtc = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeId);
                    table.ForeignKey(
                        name: "FK_Grades_Assessments_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessments",
                        principalColumn: "AssessmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grades_SchoolMemberships_StudentMembershipId",
                        column: x => x.StudentMembershipId,
                        principalTable: "SchoolMemberships",
                        principalColumn: "SchoolMembershipId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssignmentSubmissions",
                columns: table => new
                {
                    AssignmentSubmissionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssignmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentMembershipId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubmittedAtUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    TextResponse = table.Column<string>(type: "TEXT", maxLength: 10000, nullable: true),
                    AttachmentUrl = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Score = table.Column<decimal>(type: "TEXT", nullable: true),
                    Feedback = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentSubmissions", x => x.AssignmentSubmissionId);
                    table.ForeignKey(
                        name: "FK_AssignmentSubmissions_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignmentSubmissions_SchoolMemberships_StudentMembershipId",
                        column: x => x.StudentMembershipId,
                        principalTable: "SchoolMemberships",
                        principalColumn: "SchoolMembershipId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicYears_SchoolId_Name",
                table: "AcademicYears",
                columns: new[] { "SchoolId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_CourseOfferingId",
                table: "Assessments",
                column: "CourseOfferingId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CourseOfferingId",
                table: "Assignments",
                column: "CourseOfferingId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentSubmissions_AssignmentId_StudentMembershipId",
                table: "AssignmentSubmissions",
                columns: new[] { "AssignmentId", "StudentMembershipId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentSubmissions_StudentMembershipId",
                table: "AssignmentSubmissions",
                column: "StudentMembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceRecords_CourseOfferingId_StudentMembershipId_AttendanceDate",
                table: "AttendanceRecords",
                columns: new[] { "CourseOfferingId", "StudentMembershipId", "AttendanceDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceRecords_StudentMembershipId",
                table: "AttendanceRecords",
                column: "StudentMembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassGroups_AcademicYearId_Name",
                table: "ClassGroups",
                columns: new[] { "AcademicYearId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassGroups_SchoolId",
                table: "ClassGroups",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLessons_CourseOfferingId_Order",
                table: "CourseLessons",
                columns: new[] { "CourseOfferingId", "Order" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseOfferings_AcademicYearId_ClassGroupId_CourseId_Section",
                table: "CourseOfferings",
                columns: new[] { "AcademicYearId", "ClassGroupId", "CourseId", "Section" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseOfferings_ClassGroupId",
                table: "CourseOfferings",
                column: "ClassGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseOfferings_CourseId",
                table: "CourseOfferings",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseOfferings_SchoolId",
                table: "CourseOfferings",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseOfferings_TeacherMembershipId",
                table: "CourseOfferings",
                column: "TeacherMembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SchoolId_CourseCode",
                table: "Courses",
                columns: new[] { "SchoolId", "CourseCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_ClassGroupId",
                table: "Enrollments",
                column: "ClassGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentProfileId_ClassGroupId",
                table: "Enrollments",
                columns: new[] { "StudentProfileId", "ClassGroupId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_AssessmentId_StudentMembershipId",
                table: "Grades",
                columns: new[] { "AssessmentId", "StudentMembershipId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentMembershipId",
                table: "Grades",
                column: "StudentMembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_CourseOfferingId",
                table: "Schedules",
                column: "CourseOfferingId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolMemberships_SchoolId_UserId_Role",
                table: "SchoolMemberships",
                columns: new[] { "SchoolId", "UserId", "Role" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SchoolMemberships_UserId",
                table: "SchoolMemberships",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGuardians_GuardianMembershipId",
                table: "StudentGuardians",
                column: "GuardianMembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGuardians_StudentProfileId_GuardianMembershipId",
                table: "StudentGuardians",
                columns: new[] { "StudentProfileId", "GuardianMembershipId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentProfiles_SchoolMembershipId",
                table: "StudentProfiles",
                column: "SchoolMembershipId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherProfiles_SchoolMembershipId",
                table: "TeacherProfiles",
                column: "SchoolMembershipId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AssignmentSubmissions");

            migrationBuilder.DropTable(
                name: "AttendanceRecords");

            migrationBuilder.DropTable(
                name: "CourseLessons");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "StudentGuardians");

            migrationBuilder.DropTable(
                name: "TeacherProfiles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Assessments");

            migrationBuilder.DropTable(
                name: "StudentProfiles");

            migrationBuilder.DropTable(
                name: "CourseOfferings");

            migrationBuilder.DropTable(
                name: "ClassGroups");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "SchoolMemberships");

            migrationBuilder.DropTable(
                name: "AcademicYears");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Schools");
        }
    }
}
