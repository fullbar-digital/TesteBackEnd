using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteBackEnd.Infrastructure.Data.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Scores");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 9, 8, 18, 39, 476, DateTimeKind.Local).AddTicks(231),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 8, 16, 26, 38, 96, DateTimeKind.Local).AddTicks(9008));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Scores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 9, 8, 18, 39, 476, DateTimeKind.Local).AddTicks(2456),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 8, 16, 26, 38, 97, DateTimeKind.Local).AddTicks(1905));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Disciplines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 9, 8, 18, 39, 476, DateTimeKind.Local).AddTicks(1673),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 8, 16, 26, 38, 97, DateTimeKind.Local).AddTicks(835));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 9, 8, 18, 39, 476, DateTimeKind.Local).AddTicks(989),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 8, 16, 26, 38, 96, DateTimeKind.Local).AddTicks(9971));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Students");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 8, 16, 26, 38, 96, DateTimeKind.Local).AddTicks(9008),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 9, 8, 18, 39, 476, DateTimeKind.Local).AddTicks(231));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Scores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 8, 16, 26, 38, 97, DateTimeKind.Local).AddTicks(1905),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 9, 8, 18, 39, 476, DateTimeKind.Local).AddTicks(2456));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Scores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Disciplines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 8, 16, 26, 38, 97, DateTimeKind.Local).AddTicks(835),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 9, 8, 18, 39, 476, DateTimeKind.Local).AddTicks(1673));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 8, 16, 26, 38, 96, DateTimeKind.Local).AddTicks(9971),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 9, 8, 18, 39, 476, DateTimeKind.Local).AddTicks(989));
        }
    }
}
