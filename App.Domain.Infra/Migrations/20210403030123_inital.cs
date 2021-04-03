using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Domain.Infra.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COURSES",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COURSES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "STUDENTS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "varchar(150)", nullable: false),
                    REGISTER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PERIOD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STATUS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PHOTO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STUDENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_STUDENTS_COURSES_CourseId",
                        column: x => x.CourseId,
                        principalTable: "COURSES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SUBJECTS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "varchar(150)", nullable: false),
                    MIN_AVERAGE_APPROVAL = table.Column<double>(type: "float", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUBJECTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SUBJECTS_COURSES_CourseId",
                        column: x => x.CourseId,
                        principalTable: "COURSES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubjects",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Average = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubjects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentSubjects_STUDENTS_StudentId",
                        column: x => x.StudentId,
                        principalTable: "STUDENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubjects_SUBJECTS_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "SUBJECTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "COURSES",
                columns: new[] { "ID", "NAME" },
                values: new object[] { new Guid("6cae6747-c6c7-45eb-8081-b4833e16b713"), "IT Development" });

            migrationBuilder.InsertData(
                table: "COURSES",
                columns: new[] { "ID", "NAME" },
                values: new object[] { new Guid("2ce86027-efa8-44b9-8b3b-b3fd96642247"), "Software Egineering" });

            migrationBuilder.InsertData(
                table: "COURSES",
                columns: new[] { "ID", "NAME" },
                values: new object[] { new Guid("c2c4b3ea-7869-440a-8236-c6d42bb77f42"), "Biology" });

            migrationBuilder.InsertData(
                table: "STUDENTS",
                columns: new[] { "ID", "CourseId", "NAME", "PERIOD", "PHOTO", "REGISTER", "STATUS" },
                values: new object[] { new Guid("f781d43c-2ad2-46af-bbdb-d2cb849c2df9"), new Guid("6cae6747-c6c7-45eb-8081-b4833e16b713"), "Matheus Angelo", "Night", "https://via.placeholder.com/150", "D06JGF", "Active" });

            migrationBuilder.InsertData(
                table: "SUBJECTS",
                columns: new[] { "ID", "CourseId", "MIN_AVERAGE_APPROVAL", "NAME", "Status" },
                values: new object[,]
                {
                    { new Guid("9d8d776e-6a6f-49e0-b1ed-0546d50efece"), new Guid("6cae6747-c6c7-45eb-8081-b4833e16b713"), 7.0999999999999996, "Phisics", null },
                    { new Guid("6d70cff6-09d8-4a16-b487-296462538f69"), new Guid("6cae6747-c6c7-45eb-8081-b4833e16b713"), 7.0999999999999996, "Math", null },
                    { new Guid("cede3eb3-b251-4ce5-b8c4-fef9838cf76d"), new Guid("2ce86027-efa8-44b9-8b3b-b3fd96642247"), 7.0999999999999996, "OOP", null },
                    { new Guid("e7ddcd09-25a1-4791-853b-4742c9166e5d"), new Guid("c2c4b3ea-7869-440a-8236-c6d42bb77f42"), 7.0999999999999996, "HealthCare", null }
                });

            migrationBuilder.InsertData(
                table: "StudentSubjects",
                columns: new[] { "ID", "Average", "Status", "StudentId", "SubjectId" },
                values: new object[] { new Guid("b580b915-ea60-4725-8615-4ae417849d5e"), 8.0, null, new Guid("f781d43c-2ad2-46af-bbdb-d2cb849c2df9"), new Guid("9d8d776e-6a6f-49e0-b1ed-0546d50efece") });

            migrationBuilder.CreateIndex(
                name: "IX_STUDENTS_CourseId",
                table: "STUDENTS",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_StudentId",
                table: "StudentSubjects",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_SubjectId",
                table: "StudentSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SUBJECTS_CourseId",
                table: "SUBJECTS",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentSubjects");

            migrationBuilder.DropTable(
                name: "STUDENTS");

            migrationBuilder.DropTable(
                name: "SUBJECTS");

            migrationBuilder.DropTable(
                name: "COURSES");
        }
    }
}
