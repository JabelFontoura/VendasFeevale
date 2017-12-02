using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendasFeevale.Infrastructure.Entity;

namespace VendasFeevale.Infrastructure.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("email")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Senha)
                .IsRequired()
                .HasColumnName("senha")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Login)
                .IsRequired()
                .HasColumnName("login")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasColumnName("nome")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Tipo)
                .IsRequired()
                .HasColumnName("tipo")
                .HasColumnType("nchar(10)");
        }
    }
}