using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sapiens.Shared.Migrations
{
    /// <inheritdoc />
    public partial class primeiroExec : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoordenadorId",
                table: "Cursos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_CoordenadorId",
                table: "Cursos",
                column: "CoordenadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Professores_CoordenadorId",
                table: "Cursos",
                column: "CoordenadorId",
                principalTable: "Professores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Professores_CoordenadorId",
                table: "Cursos");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_CoordenadorId",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "CoordenadorId",
                table: "Cursos");
        }
    }
}
