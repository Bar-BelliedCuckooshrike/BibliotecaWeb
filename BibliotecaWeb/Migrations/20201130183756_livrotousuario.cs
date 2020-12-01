using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotecaWeb.Migrations
{
    public partial class livrotousuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "usuariologado",
                table: "Livros",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "usuariologado",
                table: "Livros");
        }
    }
}
