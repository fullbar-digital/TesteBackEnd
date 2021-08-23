using Microsoft.EntityFrameworkCore.Migrations;

namespace Fullbar.Migrations
{
    public partial class add_seeders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "CourseID", "Name" },
                values: new object[] { 1L, "Ciência da computação" });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "CourseID", "Name" },
                values: new object[] { 2L, "Engenharia da computação" });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "CourseID", "Name" },
                values: new object[] { 3L, "Engenharia de software" });

            migrationBuilder.InsertData(
                table: "Discipline",
                columns: new[] { "DisciplineID", "CourseId", "MinimumGrade", "Name" },
                values: new object[,]
                {
                    { 1L, 1L, 7.0, "Calculo 1" },
                    { 2L, 1L, 7.0, "Calculo 2" },
                    { 3L, 3L, 7.0, "Calculo 3" }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "CourseId", "Name", "Period", "Picture", "RA" },
                values: new object[,]
                {
                    { 2L, 1L, "Carlos Rodrigues", "Tarde", "carlos.jpg", "654321" },
                    { 1L, 2L, "Marco Bagdal 3", "Manha", "Marco.png", "123456" }
                });

            migrationBuilder.InsertData(
                table: "Grade",
                columns: new[] { "GradeID", "DisciplineID", "StudantGrade", "StudentID" },
                values: new object[] { 2L, 2L, 4.2300000000000004, 2L });

            migrationBuilder.InsertData(
                table: "Grade",
                columns: new[] { "GradeID", "DisciplineID", "StudantGrade", "StudentID" },
                values: new object[] { 1L, 2L, 7.2000000000000002, 1L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Discipline",
                keyColumn: "DisciplineID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Discipline",
                keyColumn: "DisciplineID",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Grade",
                keyColumn: "GradeID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Grade",
                keyColumn: "GradeID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "CourseID",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Discipline",
                keyColumn: "DisciplineID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "CourseID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "CourseID",
                keyValue: 2L);

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
    }
}
