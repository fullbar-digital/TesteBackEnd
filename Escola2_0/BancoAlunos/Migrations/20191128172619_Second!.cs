using Microsoft.EntityFrameworkCore.Migrations;

namespace BancoAlunos.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Nota",
                table: "Alunos",
                type: "Decimal(4,2)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Numeric(2,2)",
                oldMaxLength: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Nota",
                table: "Alunos",
                type: "Numeric(2,2)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(4,2)",
                oldMaxLength: 4);
        }
    }
}
