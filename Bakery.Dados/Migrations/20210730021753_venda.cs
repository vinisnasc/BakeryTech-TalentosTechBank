using Microsoft.EntityFrameworkCore.Migrations;

namespace Bakery.Dados.Migrations
{
    public partial class venda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemVenda",
                columns: table => new
                {
                    IdProduto = table.Column<int>(type: "int", nullable: false),
                    IdVenda = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVenda", x => new { x.IdProduto, x.IdVenda });
                    table.ForeignKey(
                        name: "FK_ItemVenda_ListaDeProdutos_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "ListaDeProdutos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemVenda_Venda_IdVenda",
                        column: x => x.IdVenda,
                        principalTable: "Venda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemVenda_IdVenda",
                table: "ItemVenda",
                column: "IdVenda");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemVenda");

            migrationBuilder.DropTable(
                name: "Venda");
        }
    }
}
