using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Vendas.Infrastructure.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    Tipo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IdCategoria = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    UrlImagem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Categoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cab_Venda",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Data = table.Column<DateTime>(nullable: true),
                    DataAceite = table.Column<DateTime>(nullable: true),
                    DataExpedicao = table.Column<DateTime>(nullable: true),
                    Hora = table.Column<string>(nullable: true),
                    IdUsuario = table.Column<string>(nullable: true),
                    Situacao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cab_Venda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cab_Venda_Usuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Preco",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    DataValidade = table.Column<DateTime>(nullable: true),
                    IdProduto = table.Column<string>(nullable: true),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Preco_Produtos",
                        column: x => x.IdProduto,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetVenda",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IdCabecalhoVenda = table.Column<string>(nullable: true),
                    IdPreco = table.Column<string>(nullable: true),
                    IdProduto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetVenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Det_Venda_Cab_Venda",
                        column: x => x.IdCabecalhoVenda,
                        principalTable: "Cab_Venda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Det_Venda_Preco",
                        column: x => x.IdPreco,
                        principalTable: "Preco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Det_Venda_Produtos",
                        column: x => x.IdProduto,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cab_Venda_IdUsuario",
                table: "Cab_Venda",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_DetVenda_IdCabecalhoVenda",
                table: "DetVenda",
                column: "IdCabecalhoVenda");

            migrationBuilder.CreateIndex(
                name: "IX_DetVenda_IdPreco",
                table: "DetVenda",
                column: "IdPreco");

            migrationBuilder.CreateIndex(
                name: "IX_DetVenda_IdProduto",
                table: "DetVenda",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Preco_IdProduto",
                table: "Preco",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IdCategoria",
                table: "Produtos",
                column: "IdCategoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetVenda");

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
