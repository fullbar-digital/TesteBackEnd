using Microsoft.EntityFrameworkCore.Migrations;

namespace Fullbar.Migrations
{
    public partial class removing_status_from_student_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DisciplineID",
                table: "Student",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_DisciplineID",
                table: "Student",
                column: "DisciplineID");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Discipline_DisciplineID",
                table: "Student",
                column: "DisciplineID",
                principalTable: "Discipline",
                principalColumn: "DisciplineID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Discipline_DisciplineID",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_DisciplineID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "DisciplineID",
                table: "Student");
        }
    }
}
