﻿using Microsoft.EntityFrameworkCore;
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
            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasColumnName("nome")
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}