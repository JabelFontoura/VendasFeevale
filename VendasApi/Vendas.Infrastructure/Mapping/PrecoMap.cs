using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Vendas.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vendas.Infrastructure.Mapping
{
    public class PrecoMap : IEntityTypeConfiguration<Preco>
    {
        public void Configure(EntityTypeBuilder<Preco> builder)
        {
            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Data)
                .HasColumnName("data")
                .HasColumnType("date");

            builder.Property(e => e.DataValidade)
                .HasColumnName("dataValidade")
                .HasColumnType("date");

            builder.Property(e => e.IdProduto).HasColumnName("idProduto");

            builder.Property(e => e.Valor).HasColumnName("valor");

            builder.HasOne(d => d.IdProdutoNavigation)
                .WithMany(p => p.Preco)
                .HasForeignKey(d => d.IdProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Preco_Produtos");
        }
    }
}
