using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VendasFeevale.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VendasFeevale.Infrastructure.Mapping
{
    public class DetalheVendaMap : IEntityTypeConfiguration<DetalheVenda>
    {
        public void Configure(EntityTypeBuilder<DetalheVenda> builder)
        {
            builder.ToTable("Det_Venda");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(e => e.IdCab).HasColumnName("idCab");

            builder.Property(e => e.IdPreco).HasColumnName("idPreco");

            builder.Property(e => e.IdProduto).HasColumnName("idProduto");

            builder.HasOne(d => d.IdCabNavigation)
                .WithMany(p => p.DetVenda)
                .HasForeignKey(d => d.IdCab)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Det_Venda_Cab_Venda");

            builder.HasOne(d => d.IdPrecoNavigation)
                .WithMany(p => p.DetVenda)
                .HasForeignKey(d => d.IdPreco)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Det_Venda_Preco");

            builder.HasOne(d => d.IdProdutoNavigation)
                .WithMany(p => p.DetVenda)
                .HasForeignKey(d => d.IdProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Det_Venda_Produtos");
        }
    }
}
