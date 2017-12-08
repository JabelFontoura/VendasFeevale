using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vendas.Infrastructure.Entity;

namespace Vendas.Infrastructure.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasMany(u => u.CabecalhoVenda)
                .WithOne()
                .HasForeignKey(c => c.IdUsuario);
        }
    }
}