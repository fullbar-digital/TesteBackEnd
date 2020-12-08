using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Infra.Data.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CursoInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CursoFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ra = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Periodo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aluno_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Disciplina",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NotaMinima = table.Column<double>(type: "float", nullable: false),
                    DisciplinaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisciplinaFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplina_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunoDisciplina",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nota = table.Column<double>(type: "float", nullable: false),
                    RelacaoAlunoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlunoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RelacaoDisciplinaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisciplinaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoDisciplina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlunoDisciplina_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlunoDisciplina_Disciplina_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_CursoId",
                table: "Aluno",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_Ra",
                table: "Aluno",
                column: "Ra",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlunoDisciplina_AlunoId",
                table: "AlunoDisciplina",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoDisciplina_DisciplinaId",
                table: "AlunoDisciplina",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_CursoId",
                table: "Disciplina",
                column: "CursoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoDisciplina");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Disciplina");

            migrationBuilder.DropTable(
                name: "Curso");
        }
    }
}