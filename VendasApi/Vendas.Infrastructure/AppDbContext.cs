using Microsoft.EntityFrameworkCore;
using Vendas.Infrastructure.Entity;

namespace Vendas.Infrastructure
{
    public class AppDbContext: DbContext
    {
        public virtual DbSet<CabecalhoVenda> CabVenda { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<DetalheVenda> DetVenda { get; set; }
        public virtual DbSet<Preco> Preco { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        private string ConnectionString;

        public AppDbContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=JABEL-NOTE\SQLEXPRESS;Database=Vendas_Feevale;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new UsuarioMap());
            //modelBuilder.ApplyConfiguration(new CabecalhoVendaMap());
            //modelBuilder.ApplyConfiguration(new CategoriaMap());
            //modelBuilder.ApplyConfiguration(new PrecoMap());
            //modelBuilder.ApplyConfiguration(new DetalheVendaMap());
            //modelBuilder.ApplyConfiguration(new ProdutoMap());
        }
    }
}
