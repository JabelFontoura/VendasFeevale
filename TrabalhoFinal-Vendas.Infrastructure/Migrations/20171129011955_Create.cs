using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TrabalhoFinalVendas.Infrastructure.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    email = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    login = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    nome = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    senha = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    tipo = table.Column<int>(type: "nchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idCategoria = table.Column<int>(nullable: false),
                    nome = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Produtos_Categoria",
                        column: x => x.idCategoria,
                        principalTable: "Categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cab_Venda",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    data = table.Column<DateTime>(type: "date", nullable: false),
                    dataAceite = table.Column<DateTime>(type: "date", nullable: false),
                    dataExpedicao = table.Column<DateTime>(type: "date", nullable: false),
                    hora = table.Column<string>(type: "nchar(6)", nullable: false),
                    idCliente = table.Column<int>(nullable: false),
                    situacao = table.Column<int>(type: "nchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cab_Venda", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cab_Venda_Usuario",
                        column: x => x.idCliente,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Preco",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    data = table.Column<DateTime>(type: "date", nullable: false),
                    dataValidade = table.Column<DateTime>(type: "date", nullable: true),
                    idProduto = table.Column<int>(nullable: false),
                    valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preco", x => x.id);
                    table.ForeignKey(
                        name: "FK_Preco_Produtos",
                        column: x => x.idProduto,
                        principalTable: "Produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Det_Venda",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    idCab = table.Column<int>(nullable: false),
                    idPreco = table.Column<int>(nullable: false),
                    idProduto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Det_Venda", x => x.id);
                    table.ForeignKey(
                        name: "FK_Det_Venda_Cab_Venda",
                        column: x => x.idCab,
                        principalTable: "Cab_Venda",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Det_Venda_Preco",
                        column: x => x.idPreco,
                        principalTable: "Preco",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Det_Venda_Produtos",
                        column: x => x.idProduto,
                        principalTable: "Produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cab_Venda_idCliente",
                table: "Cab_Venda",
                column: "idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Det_Venda_idCab",
                table: "Det_Venda",
                column: "idCab");

            migrationBuilder.CreateIndex(
                name: "IX_Det_Venda_idPreco",
                table: "Det_Venda",
                column: "idPreco");

            migrationBuilder.CreateIndex(
                name: "IX_Det_Venda_idProduto",
                table: "Det_Venda",
                column: "idProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Preco_idProduto",
                table: "Preco",
                column: "idProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_idCategoria",
                table: "Produtos",
                column: "idCategoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Det_Venda");

            migrationBuilder.DropTable(
                name: "Cab_Venda");

            migrationBuilder.DropTable(
                name: "Preco");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
