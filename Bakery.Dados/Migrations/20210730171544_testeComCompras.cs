using Microsoft.EntityFrameworkCore.Migrations;

namespace Bakery.Dados.Migrations
{
    public partial class testeComCompras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Realizada",
                table: "Compra",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Realizada",
                table: "Compra");
        }
    }
}
