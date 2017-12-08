using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Vendas.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vendas.Infrastructure.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {

            builder.HasOne(d => d.Categoria)
                .WithMany(p => p.Produtos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Produtos_Categoria");
        }
    }
}
