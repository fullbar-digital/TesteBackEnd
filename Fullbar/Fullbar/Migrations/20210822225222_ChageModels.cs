using Microsoft.EntityFrameworkCore.Migrations;

namespace Fullbar.Migrations
{
    public partial class ChageModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "Enrollment");

            migrationBuilder.RenameColumn(
                name: "CurrentCourseId",
                table: "Student",
                newName: "CourseId");

            migrationBuilder.AddColumn<long>(
                name: "CourseID",
                table: "Discipline",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_CourseId",
                table: "Student",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Discipline_CourseID",
                table: "Discipline",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Discipline_Course_CourseID",
                table: "Discipline",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Course_CourseId",
                table: "Student",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discipline_Course_CourseID",
                table: "Discipline");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Course_CourseId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_CourseId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Discipline_CourseID",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "Discipline");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Student",
                newName: "CurrentCourseId");

            migrationBuilder.AddColumn<int>(
                name: "StudentID",
                table: "Enrollment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
