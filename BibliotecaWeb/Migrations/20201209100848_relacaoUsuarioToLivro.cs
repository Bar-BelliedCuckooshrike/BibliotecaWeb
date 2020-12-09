using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotecaWeb.Migrations
{
    public partial class relacaoUsuarioToLivro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Livros",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Livros_UsuarioId",
                table: "Livros",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_AspNetUsers_UsuarioId",
                table: "Livros",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_AspNetUsers_UsuarioId",
                table: "Livros");

            migrationBuilder.DropIndex(
                name: "IX_Livros_UsuarioId",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Livros");
        }
    }
}
