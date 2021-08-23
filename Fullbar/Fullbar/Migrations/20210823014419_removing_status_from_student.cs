using Microsoft.EntityFrameworkCore.Migrations;

namespace Fullbar.Migrations
{
    public partial class removing_status_from_student : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Student");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
