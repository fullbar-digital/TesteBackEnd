using Microsoft.EntityFrameworkCore.Migrations;

namespace Fullbar.Migrations
{
    public partial class adding_grade_on_discipline_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discipline_Course_CourseID",
                table: "Discipline");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Discipline",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Discipline_CourseID",
                table: "Discipline",
                newName: "IX_Discipline_CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discipline_Course_CourseId",
                table: "Discipline",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discipline_Course_CourseId",
                table: "Discipline");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Discipline",
                newName: "CourseID");

            migrationBuilder.RenameIndex(
                name: "IX_Discipline_CourseId",
                table: "Discipline",
                newName: "IX_Discipline_CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Discipline_Course_CourseID",
                table: "Discipline",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
