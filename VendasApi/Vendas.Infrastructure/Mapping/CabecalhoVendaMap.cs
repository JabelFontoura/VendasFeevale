using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Vendas.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vendas.Infrastructure.Mapping
{
    public class CabecalhoVendaMap : IEntityTypeConfiguration<CabecalhoVenda>
    {
        public void Configure(EntityTypeBuilder<CabecalhoVenda> builder)
        {
            builder.ToTable("Cab_Venda");

            builder.HasOne(d => d.Usuario)
                .WithMany(p => p.CabecalhoVenda)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cab_Venda_Usuario");

            builder.HasMany(d => d.DetalheVendas)
                .WithOne()
                .HasForeignKey(d => d.IdCabecalhoVenda);
        }
    }
}
