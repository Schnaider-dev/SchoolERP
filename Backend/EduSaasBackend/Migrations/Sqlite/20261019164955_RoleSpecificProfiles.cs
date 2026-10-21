using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduSaasBackend.Migrations.Sqlite
{
    /// <inheritdoc />
    public partial class RoleSpecificProfiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentSubmissions_SchoolMemberships_StudentMembershipId",
                table: "AssignmentSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceRecords_SchoolMemberships_StudentMembershipId",
                table: "AttendanceRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassGroups_AcademicYears_AcademicYearId",
                table: "ClassGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseOfferings_SchoolMemberships_TeacherMembershipId",
                table: "CourseOfferings");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_SchoolMemberships_StudentMembershipId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentGuardians_SchoolMemberships_GuardianMembershipId",
                table: "StudentGuardians");

            migrationBuilder.RenameColumn(
                name: "GuardianMembershipId",
                table: "StudentGuardians",
                newName: "GuardianProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentGuardians_StudentProfileId_GuardianMembershipId",
                table: "StudentGuardians",
                newName: "IX_StudentGuardians_StudentProfileId_GuardianProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentGuardians_GuardianMembershipId",
                table: "StudentGuardians",
                newName: "IX_StudentGuardians_GuardianProfileId");

            migrationBuilder.RenameColumn(
                name: "StudentMembershipId",
                table: "Grades",
                newName: "StudentProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_StudentMembershipId",
                table: "Grades",
                newName: "IX_Grades_StudentProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_AssessmentId_StudentMembershipId",
                table: "Grades",
                newName: "IX_Grades_AssessmentId_StudentProfileId");

            migrationBuilder.RenameColumn(
                name: "TeacherMembershipId",
                table: "CourseOfferings",
                newName: "TeacherProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseOfferings_TeacherMembershipId",
                table: "CourseOfferings",
                newName: "IX_CourseOfferings_TeacherProfileId");

            migrationBuilder.RenameColumn(
                name: "StudentMembershipId",
                table: "AttendanceRecords",
                newName: "StudentProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceRecords_StudentMembershipId",
                table: "AttendanceRecords",
                newName: "IX_AttendanceRecords_StudentProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceRecords_CourseOfferingId_StudentMembershipId_AttendanceDate",
                table: "AttendanceRecords",
                newName: "IX_AttendanceRecords_CourseOfferingId_StudentProfileId_AttendanceDate");

            migrationBuilder.RenameColumn(
                name: "StudentMembershipId",
                table: "AssignmentSubmissions",
                newName: "StudentProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentSubmissions_StudentMembershipId",
                table: "AssignmentSubmissions",
                newName: "IX_AssignmentSubmissions_StudentProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentSubmissions_AssignmentId_StudentMembershipId",
                table: "AssignmentSubmissions",
                newName: "IX_AssignmentSubmissions_AssignmentId_StudentProfileId");

            migrationBuilder.CreateTable(
                name: "GuardianProfiles",
                columns: table => new
                {
                    GuardianProfileId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SchoolMembershipId = table.Column<int>(type: "INTEGER", nullable: false),
                    Employer = table.Column<string>(type: "TEXT", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuardianProfiles", x => x.GuardianProfileId);
                    table.ForeignKey(
                        name: "FK_GuardianProfiles_SchoolMemberships_SchoolMembershipId",
                        column: x => x.SchoolMembershipId,
                        principalTable: "SchoolMemberships",
                        principalColumn: "SchoolMembershipId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuardianProfiles_SchoolMembershipId",
                table: "GuardianProfiles",
                column: "SchoolMembershipId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentSubmissions_StudentProfiles_StudentProfileId",
                table: "AssignmentSubmissions",
                column: "StudentProfileId",
                principalTable: "StudentProfiles",
                principalColumn: "StudentProfileId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceRecords_StudentProfiles_StudentProfileId",
                table: "AttendanceRecords",
                column: "StudentProfileId",
                principalTable: "StudentProfiles",
                principalColumn: "StudentProfileId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassGroups_AcademicYears_AcademicYearId",
                table: "ClassGroups",
                column: "AcademicYearId",
                principalTable: "AcademicYears",
                principalColumn: "AcademicYearId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseOfferings_TeacherProfiles_TeacherProfileId",
                table: "CourseOfferings",
                column: "TeacherProfileId",
                principalTable: "TeacherProfiles",
                principalColumn: "TeacherProfileId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_StudentProfiles_StudentProfileId",
                table: "Grades",
                column: "StudentProfileId",
                principalTable: "StudentProfiles",
                principalColumn: "StudentProfileId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGuardians_GuardianProfiles_GuardianProfileId",
                table: "StudentGuardians",
                column: "GuardianProfileId",
                principalTable: "GuardianProfiles",
                principalColumn: "GuardianProfileId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentSubmissions_StudentProfiles_StudentProfileId",
                table: "AssignmentSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceRecords_StudentProfiles_StudentProfileId",
                table: "AttendanceRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassGroups_AcademicYears_AcademicYearId",
                table: "ClassGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseOfferings_TeacherProfiles_TeacherProfileId",
                table: "CourseOfferings");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_StudentProfiles_StudentProfileId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentGuardians_GuardianProfiles_GuardianProfileId",
                table: "StudentGuardians");

            migrationBuilder.DropTable(
                name: "GuardianProfiles");

            migrationBuilder.RenameColumn(
                name: "GuardianProfileId",
                table: "StudentGuardians",
                newName: "GuardianMembershipId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentGuardians_StudentProfileId_GuardianProfileId",
                table: "StudentGuardians",
                newName: "IX_StudentGuardians_StudentProfileId_GuardianMembershipId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentGuardians_GuardianProfileId",
                table: "StudentGuardians",
                newName: "IX_StudentGuardians_GuardianMembershipId");

            migrationBuilder.RenameColumn(
                name: "StudentProfileId",
                table: "Grades",
                newName: "StudentMembershipId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_StudentProfileId",
                table: "Grades",
                newName: "IX_Grades_StudentMembershipId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_AssessmentId_StudentProfileId",
                table: "Grades",
                newName: "IX_Grades_AssessmentId_StudentMembershipId");

            migrationBuilder.RenameColumn(
                name: "TeacherProfileId",
                table: "CourseOfferings",
                newName: "TeacherMembershipId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseOfferings_TeacherProfileId",
                table: "CourseOfferings",
                newName: "IX_CourseOfferings_TeacherMembershipId");

            migrationBuilder.RenameColumn(
                name: "StudentProfileId",
                table: "AttendanceRecords",
                newName: "StudentMembershipId");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceRecords_StudentProfileId",
                table: "AttendanceRecords",
                newName: "IX_AttendanceRecords_StudentMembershipId");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceRecords_CourseOfferingId_StudentProfileId_AttendanceDate",
                table: "AttendanceRecords",
                newName: "IX_AttendanceRecords_CourseOfferingId_StudentMembershipId_AttendanceDate");

            migrationBuilder.RenameColumn(
                name: "StudentProfileId",
                table: "AssignmentSubmissions",
                newName: "StudentMembershipId");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentSubmissions_StudentProfileId",
                table: "AssignmentSubmissions",
                newName: "IX_AssignmentSubmissions_StudentMembershipId");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentSubmissions_AssignmentId_StudentProfileId",
                table: "AssignmentSubmissions",
                newName: "IX_AssignmentSubmissions_AssignmentId_StudentMembershipId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentSubmissions_SchoolMemberships_StudentMembershipId",
                table: "AssignmentSubmissions",
                column: "StudentMembershipId",
                principalTable: "SchoolMemberships",
                principalColumn: "SchoolMembershipId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceRecords_SchoolMemberships_StudentMembershipId",
                table: "AttendanceRecords",
                column: "StudentMembershipId",
                principalTable: "SchoolMemberships",
                principalColumn: "SchoolMembershipId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassGroups_AcademicYears_AcademicYearId",
                table: "ClassGroups",
                column: "AcademicYearId",
                principalTable: "AcademicYears",
                principalColumn: "AcademicYearId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseOfferings_SchoolMemberships_TeacherMembershipId",
                table: "CourseOfferings",
                column: "TeacherMembershipId",
                principalTable: "SchoolMemberships",
                principalColumn: "SchoolMembershipId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_SchoolMemberships_StudentMembershipId",
                table: "Grades",
                column: "StudentMembershipId",
                principalTable: "SchoolMemberships",
                principalColumn: "SchoolMembershipId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGuardians_SchoolMemberships_GuardianMembershipId",
                table: "StudentGuardians",
                column: "GuardianMembershipId",
                principalTable: "SchoolMemberships",
                principalColumn: "SchoolMembershipId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
