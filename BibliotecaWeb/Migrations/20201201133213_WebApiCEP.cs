using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotecaWeb.Migrations
{
    public partial class WebApiCEP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Usuarios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Usuarios");
        }
    }
}
