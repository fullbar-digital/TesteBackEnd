using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class AlunosNovo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunoDisciplinas_Disciplinas_AlunoID",
                table: "AlunoDisciplinas");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoDisciplinas_DisciplinaID",
                table: "AlunoDisciplinas",
                column: "DisciplinaID");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoDisciplinas_Disciplinas_DisciplinaID",
                table: "AlunoDisciplinas",
                column: "DisciplinaID",
                principalTable: "Disciplinas",
                principalColumn: "DisciplinaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunoDisciplinas_Disciplinas_DisciplinaID",
                table: "AlunoDisciplinas");

            migrationBuilder.DropIndex(
                name: "IX_AlunoDisciplinas_DisciplinaID",
                table: "AlunoDisciplinas");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoDisciplinas_Disciplinas_AlunoID",
                table: "AlunoDisciplinas",
                column: "AlunoID",
                principalTable: "Disciplinas",
                principalColumn: "DisciplinaID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
