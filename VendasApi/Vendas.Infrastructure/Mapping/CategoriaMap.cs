using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Vendas.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vendas.Infrastructure.Mapping
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasMany(c => c.Produtos)
                .WithOne()
                .HasForeignKey(p => p.IdCategoria);
        }
    }
}
