﻿using Microsoft.EntityFrameworkCore;
using System;
using TrabalhoFinal_Vendas.Infrastructure.Entity;
using TrabalhoFinal_Vendas.Infrastructure.Mapping;

namespace TrabalhoFinal_Vendas.Infrastructure
{
    public class AppContext: DbContext
    {
        public virtual DbSet<CabecalhoVenda> CabVenda { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<DetalheVenda> DetVenda { get; set; }
        public virtual DbSet<Preco> Preco { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        private string ConnectionString;

        public AppContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=JABEL-NOTE\SQLEXPRESS;Database=Vendas_Feevale;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new CabecalhoVendaMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new PrecoMap());
            modelBuilder.ApplyConfiguration(new DetalheVendaMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }
    }
}
