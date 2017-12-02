using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VendasFeevale.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VendasFeevale.Infrastructure.Mapping
{
    public class CabecalhoVendaMap : IEntityTypeConfiguration<CabecalhoVenda>
    {
        public void Configure(EntityTypeBuilder<CabecalhoVenda> builder)
        {
            builder.ToTable("Cab_Venda");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Data)
                .HasColumnName("data")
                .HasColumnType("date");

            builder.Property(e => e.DataAceite)
                .HasColumnName("dataAceite")
                .HasColumnType("date");

            builder.Property(e => e.DataExpedicao)
                .HasColumnName("dataExpedicao")
                .HasColumnType("date");

            builder.Property(e => e.Hora)
                .IsRequired()
                .HasColumnName("hora")
                .HasColumnType("nchar(6)");

            builder.Property(e => e.IdCliente).HasColumnName("idCliente");

            builder.Property(e => e.Situacao)
                .IsRequired()
                .HasColumnName("situacao")
                .HasColumnType("nchar(1)");

            builder.HasOne(d => d.IdClienteNavigation)
                .WithMany(p => p.CabVenda)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cab_Venda_Usuario");
        }
    }
}
