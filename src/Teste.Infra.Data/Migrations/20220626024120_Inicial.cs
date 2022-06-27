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
                    CURSO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FOTO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STATUS = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ALUNO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ALUNO_CURSO",
                        column: x => x.CURSO_ID,
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

            migrationBuilder.InsertData(
                table: "TB_CURSO",
                columns: new[] { "ID", "NOME" },
                values: new object[] { new Guid("36f5ec76-d5a5-4eff-949b-2fe44dad5a0e"), "CURSO 002" });

            migrationBuilder.InsertData(
                table: "TB_CURSO",
                columns: new[] { "ID", "NOME" },
                values: new object[] { new Guid("47638e27-2992-4021-bd4c-9d3ddbbab597"), "CURSO 001" });

            migrationBuilder.InsertData(
                table: "TB_ALUNO",
                columns: new[] { "ID", "CURSO_ID", "FOTO", "NOME", "PERIODO", "REGISTRO_ACADEMICO", "STATUS" },
                values: new object[,]
                {
                    { new Guid("7ad63a53-6571-4d0f-a293-8d5330c73765"), new Guid("36f5ec76-d5a5-4eff-949b-2fe44dad5a0e"), "https://norwaytoday.info/wp-content/uploads/2020/10/Magnus-Carlsen-Heiko-Junge-NTB-1.jpg", "Magnus Carlsen", 5, "000102", null },
                    { new Guid("88046518-38ac-48cf-a621-8bdf0dab8978"), new Guid("47638e27-2992-4021-bd4c-9d3ddbbab597"), "https://i1.wp.com/dailychessmusings.com/wp-content/uploads/2020/04/bcf95-20130904_kasparov_0111_edit_1363-2.jpg?ssl=1", "Garry Kasparov", 8, "000101", null }
                });

            migrationBuilder.InsertData(
                table: "TB_DISCIPLINA",
                columns: new[] { "ID", "CURSO_ID", "NOME", "NOTA_MINIMA_APROVACAO" },
                values: new object[,]
                {
                    { new Guid("1a37f0c1-f186-4963-bb44-bb83e8c76187"), new Guid("36f5ec76-d5a5-4eff-949b-2fe44dad5a0e"), "DISCIPLINA 005", 9.00m },
                    { new Guid("6b9bc30a-2e90-43fb-8a98-3da2c8912e9a"), new Guid("47638e27-2992-4021-bd4c-9d3ddbbab597"), "DISCIPLINA 002", 6.00m },
                    { new Guid("776b9fd4-4414-4989-bffd-ee14db822d16"), new Guid("47638e27-2992-4021-bd4c-9d3ddbbab597"), "DISCIPLINA 001", 7.00m },
                    { new Guid("b3528f60-bac1-442b-aa77-8ca4de5be350"), new Guid("36f5ec76-d5a5-4eff-949b-2fe44dad5a0e"), "DISCIPLINA 006", 10.00m },
                    { new Guid("cc14e9f5-e7e7-4a43-a1a0-7974007e0cb6"), new Guid("47638e27-2992-4021-bd4c-9d3ddbbab597"), "DISCIPLINA 003", 8.00m },
                    { new Guid("e7653c09-8df8-4bc7-a2db-4b07c6cf708b"), new Guid("36f5ec76-d5a5-4eff-949b-2fe44dad5a0e"), "DISCIPLINA 004", 5.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ALUNO_CURSO_ID",
                table: "TB_ALUNO",
                column: "CURSO_ID");

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
