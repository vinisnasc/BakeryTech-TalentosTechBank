using Microsoft.EntityFrameworkCore.Migrations;

namespace Bakery.Dados.Migrations
{
    public partial class financeiro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Financeiro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaldoEmCaixa = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financeiro", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Financeiro",
                columns: new[] { "Id", "SaldoEmCaixa" },
                values: new object[] { 1, 0.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Financeiro");
        }
    }
}
