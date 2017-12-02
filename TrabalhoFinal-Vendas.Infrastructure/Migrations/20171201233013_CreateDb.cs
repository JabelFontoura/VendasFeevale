using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TrabalhoFinalVendas.Infrastructure.Migrations
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
                    IdCategoriaNavigationId = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Categoria_IdCategoriaNavigationId",
                        column: x => x.IdCategoriaNavigationId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CabVenda",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    DataAceite = table.Column<DateTime>(nullable: false),
                    DataExpedicao = table.Column<DateTime>(nullable: false),
                    Hora = table.Column<string>(nullable: true),
                    IdCliente = table.Column<string>(nullable: true),
                    IdClienteNavigationId = table.Column<string>(nullable: true),
                    Situacao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabVenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CabVenda_Usuario_IdClienteNavigationId",
                        column: x => x.IdClienteNavigationId,
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
                    IdProdutoNavigationId = table.Column<string>(nullable: true),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Preco_Produtos_IdProdutoNavigationId",
                        column: x => x.IdProdutoNavigationId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetVenda",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IdCab = table.Column<string>(nullable: true),
                    IdCabNavigationId = table.Column<string>(nullable: true),
                    IdPreco = table.Column<string>(nullable: true),
                    IdPrecoNavigationId = table.Column<string>(nullable: true),
                    IdProduto = table.Column<string>(nullable: true),
                    IdProdutoNavigationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetVenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetVenda_CabVenda_IdCabNavigationId",
                        column: x => x.IdCabNavigationId,
                        principalTable: "CabVenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetVenda_Preco_IdPrecoNavigationId",
                        column: x => x.IdPrecoNavigationId,
                        principalTable: "Preco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetVenda_Produtos_IdProdutoNavigationId",
                        column: x => x.IdProdutoNavigationId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CabVenda_IdClienteNavigationId",
                table: "CabVenda",
                column: "IdClienteNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_DetVenda_IdCabNavigationId",
                table: "DetVenda",
                column: "IdCabNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_DetVenda_IdPrecoNavigationId",
                table: "DetVenda",
                column: "IdPrecoNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_DetVenda_IdProdutoNavigationId",
                table: "DetVenda",
                column: "IdProdutoNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Preco_IdProdutoNavigationId",
                table: "Preco",
                column: "IdProdutoNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IdCategoriaNavigationId",
                table: "Produtos",
                column: "IdCategoriaNavigationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetVenda");

            migrationBuilder.DropTable(
                name: "CabVenda");

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
