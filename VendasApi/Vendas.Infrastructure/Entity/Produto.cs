using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Vendas.Infrastructure.Entity
{
    public partial class Produto
    {
        public Produto()
        {
            DetalheVendas = new HashSet<DetalheVenda>();
            Preco = new HashSet<Preco>();
        }

        public string Id { get; set; }
        public string Nome { get; set; }
        public string UrlImagem { get; set; }

        public string IdCategoria { get; set; }
        public virtual Categoria Categoria { get; set; }

        public virtual ICollection<Preco> Preco { get; set; }
        public virtual ICollection<DetalheVenda> DetalheVendas { get; set; }
    }
}
