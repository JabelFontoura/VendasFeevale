﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Vendas.Infrastructure;
using Vendas.Infrastructure.Entities.Enums;

namespace Vendas.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Vendas.Infrastructure.Entity.CabecalhoVenda", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data");

                    b.Property<DateTime?>("DataAceite");

                    b.Property<DateTime>("DataExpedicao");

                    b.Property<string>("Hora");

                    b.Property<string>("IdUsuario");

                    b.Property<int>("Situacao");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Cab_Venda");
                });

            modelBuilder.Entity("Vendas.Infrastructure.Entity.Categoria", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Vendas.Infrastructure.Entity.DetalheVenda", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IdCabecalhoVenda");

                    b.Property<string>("IdPreco");

                    b.Property<string>("IdProduto");

                    b.HasKey("Id");

                    b.HasIndex("IdCabecalhoVenda");

                    b.HasIndex("IdPreco");

                    b.HasIndex("IdProduto");

                    b.ToTable("DetVenda");
                });

            modelBuilder.Entity("Vendas.Infrastructure.Entity.Preco", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data");

                    b.Property<DateTime?>("DataValidade");

                    b.Property<string>("IdProduto");

                    b.Property<double>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("IdProduto");

                    b.ToTable("Preco");
                });

            modelBuilder.Entity("Vendas.Infrastructure.Entity.Produto", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IdCategoria");

                    b.Property<string>("Nome");

                    b.Property<string>("UrlImagem");

                    b.HasKey("Id");

                    b.HasIndex("IdCategoria");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Vendas.Infrastructure.Entity.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Login");

                    b.Property<string>("Nome");

                    b.Property<string>("Senha");

                    b.Property<int>("Tipo");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Vendas.Infrastructure.Entity.CabecalhoVenda", b =>
                {
                    b.HasOne("Vendas.Infrastructure.Entity.Usuario", "Usuario")
                        .WithMany("CabecalhoVenda")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK_Cab_Venda_Usuario");
                });

            modelBuilder.Entity("Vendas.Infrastructure.Entity.DetalheVenda", b =>
                {
                    b.HasOne("Vendas.Infrastructure.Entity.CabecalhoVenda", "CabecalhoVenda")
                        .WithMany("DetalheVendas")
                        .HasForeignKey("IdCabecalhoVenda")
                        .HasConstraintName("FK_Det_Venda_Cab_Venda");

                    b.HasOne("Vendas.Infrastructure.Entity.Preco", "Preco")
                        .WithMany("DetalheVendas")
                        .HasForeignKey("IdPreco")
                        .HasConstraintName("FK_Det_Venda_Preco");

                    b.HasOne("Vendas.Infrastructure.Entity.Produto", "Produto")
                        .WithMany("DetalheVendas")
                        .HasForeignKey("IdProduto")
                        .HasConstraintName("FK_Det_Venda_Produtos");
                });

            modelBuilder.Entity("Vendas.Infrastructure.Entity.Preco", b =>
                {
                    b.HasOne("Vendas.Infrastructure.Entity.Produto", "Produto")
                        .WithMany("Preco")
                        .HasForeignKey("IdProduto")
                        .HasConstraintName("FK_Preco_Produtos");
                });

            modelBuilder.Entity("Vendas.Infrastructure.Entity.Produto", b =>
                {
                    b.HasOne("Vendas.Infrastructure.Entity.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("IdCategoria")
                        .HasConstraintName("FK_Produtos_Categoria");
                });
#pragma warning restore 612, 618
        }
    }
}
