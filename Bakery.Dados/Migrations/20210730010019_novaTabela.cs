using Microsoft.EntityFrameworkCore.Migrations;

namespace Bakery.Dados.Migrations
{
    public partial class novaTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListaDeProdutos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    TipoDeMedida = table.Column<int>(type: "int", nullable: false),
                    TipoDeProduto = table.Column<int>(type: "int", nullable: false),
                    ValorVenda = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaDeProdutos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantidade = table.Column<double>(type: "float", nullable: false),
                    QuantidadeMin = table.Column<double>(type: "float", nullable: false),
                    IdProduto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estoque_ListaDeProdutos_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "ListaDeProdutos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialReceita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoId = table.Column<int>(type: "int", nullable: true),
                    IdProduto = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialReceita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialReceita_ListaDeProdutos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "ListaDeProdutos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_IdProduto",
                table: "Estoque",
                column: "IdProduto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaterialReceita_ProdutoId",
                table: "MaterialReceita",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropTable(
                name: "MaterialReceita");

            migrationBuilder.DropTable(
                name: "ListaDeProdutos");
        }
    }
}
