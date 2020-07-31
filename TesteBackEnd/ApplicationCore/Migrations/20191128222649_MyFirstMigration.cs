using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationCore.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Curso",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aluno",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    CursoId = table.Column<short>(nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Ra = table.Column<string>(maxLength: 20, nullable: false),
                    PeriodoInicial = table.Column<DateTime>(nullable: false),
                    PeriodoFinal = table.Column<DateTime>(nullable: false),
                    Nota = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aluno_Curso_CursoId",
                        column: x => x.CursoId,
                        principalSchema: "dbo",
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Curso",
                columns: new[] { "Id", "Ativo", "DataCriacao", "Nome", "DataAlteracao" },
                values: new object[,]
                {
                    { (short)1, true, new DateTime(2019, 11, 28, 19, 26, 48, 766, DateTimeKind.Local).AddTicks(6398), "Administração", new DateTime(2019, 11, 28, 19, 26, 48, 766, DateTimeKind.Local).AddTicks(6398) },
                    { (short)2, true, new DateTime(2019, 11, 28, 19, 26, 48, 766, DateTimeKind.Local).AddTicks(6398), "Ciências Contábeis", new DateTime(2019, 11, 28, 19, 26, 48, 766, DateTimeKind.Local).AddTicks(6398) },
                    { (short)3, true, new DateTime(2019, 11, 28, 19, 26, 48, 766, DateTimeKind.Local).AddTicks(6398), "Ciências Econômicas", new DateTime(2019, 11, 28, 19, 26, 48, 766, DateTimeKind.Local).AddTicks(6398) },
                    { (short)4, true, new DateTime(2019, 11, 28, 19, 26, 48, 766, DateTimeKind.Local).AddTicks(6398), "Comércio Exterior", new DateTime(2019, 11, 28, 19, 26, 48, 766, DateTimeKind.Local).AddTicks(6398) },
                    { (short)5, true, new DateTime(2019, 11, 28, 19, 26, 48, 766, DateTimeKind.Local).AddTicks(6398), "Design de Moda", new DateTime(2019, 11, 28, 19, 26, 48, 766, DateTimeKind.Local).AddTicks(6398) },
                    { (short)6, true, new DateTime(2019, 11, 28, 19, 26, 48, 766, DateTimeKind.Local).AddTicks(6398), "Gastronomia", new DateTime(2019, 11, 28, 19, 26, 48, 766, DateTimeKind.Local).AddTicks(6398) },
                    { (short)7, true, new DateTime(2019, 11, 28, 19, 26, 48, 766, DateTimeKind.Local).AddTicks(6398), "Gestão Comercial", new DateTime(2019, 11, 28, 19, 26, 48, 766, DateTimeKind.Local).AddTicks(6398) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_CursoId",
                schema: "dbo",
                table: "Aluno",
                column: "CursoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluno",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Curso",
                schema: "dbo");
        }
    }
}
