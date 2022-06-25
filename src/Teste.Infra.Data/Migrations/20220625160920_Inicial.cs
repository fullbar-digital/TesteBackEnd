using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teste.Infra.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CURSO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CURSO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_ALUNO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    REGISTRO_ACADEMICO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PERIODO = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    FOTO = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ALUNO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ALUNO_CURSO",
                        column: x => x.CursoId,
                        principalTable: "TB_CURSO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_DISCIPLINA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NOTA_MINIMA_APROVACAO = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CURSO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DISCIPLINA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CURSO_DISCIPLINA",
                        column: x => x.CURSO_ID,
                        principalTable: "TB_CURSO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ALUNO_CursoId",
                table: "TB_ALUNO",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_DISCIPLINA_CURSO_ID",
                table: "TB_DISCIPLINA",
                column: "CURSO_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ALUNO");

            migrationBuilder.DropTable(
                name: "TB_DISCIPLINA");

            migrationBuilder.DropTable(
                name: "TB_CURSO");
        }
    }
}
