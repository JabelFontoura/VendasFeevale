using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Vendas.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vendas.Infrastructure.Mapping
{
    public class DetalheVendaMap : IEntityTypeConfiguration<DetalheVenda>
    {
        public void Configure(EntityTypeBuilder<DetalheVenda> builder)
        {
            builder.HasOne(d => d.CabecalhoVenda)
                .WithMany(p => p.DetalheVendas)
                .HasForeignKey(d => d.IdCabecalhoVenda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Det_Venda_Cab_Venda");

            builder.HasOne(d => d.Preco)
                .WithMany(p => p.DetalheVendas)
                .HasForeignKey(d => d.IdPreco)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Det_Venda_Preco");

            builder.HasOne(d => d.Produto)
                .WithMany(p => p.DetalheVendas)
                .HasForeignKey(d => d.IdProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Det_Venda_Produtos");
        }
    }
}
