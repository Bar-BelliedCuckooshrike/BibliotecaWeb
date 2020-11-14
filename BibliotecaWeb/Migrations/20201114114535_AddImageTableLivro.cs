using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotecaWeb.Migrations
{
    public partial class AddImageTableLivro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imagem",
                table: "Livros",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imagem",
                table: "Livros");
        }
    }
}
