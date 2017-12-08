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

            builder.HasOne(d => d.Produto)
                .WithMany(p => p.Preco)
                .HasForeignKey(d => d.IdProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Preco_Produtos");

            builder.HasMany(p => p.DetalheVendas)
                .WithOne()
                .HasForeignKey(p => p.IdPreco);
        }
    }
}
