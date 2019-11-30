using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentRegistration.WebApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Option = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AR = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Period = table.Column<int>(nullable: false),
                    Course = table.Column<int>(nullable: false),
                    Grade = table.Column<double>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "ID", "Option" },
                values: new object[,]
                {
                    { 1, "Arquitetura de Urbanismo" },
                    { 2, "Biologia" },
                    { 3, "Ciência da Computação" },
                    { 4, "Engenharia" },
                    { 5, "Fisioterapia" },
                    { 6, "Literatura" },
                    { 7, "Matemática" },
                    { 8, "Relações Internacionais" },
                    { 9, "Sistemas de Informação" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
