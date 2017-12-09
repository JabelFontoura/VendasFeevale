using System;
using System.Collections.Generic;

namespace Vendas.Infrastructure.Entity
{
    public partial class Preco
    {
        public Preco()
        {
            DetalheVendas = new HashSet<DetalheVenda>();
        }

        public string Id { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
        public DateTime? DataValidade { get; set; }

        public virtual Produto Produto { get; set; }
        public virtual ICollection<DetalheVenda> DetalheVendas { get; set; }
        public virtual string IdProduto { get; set; }
    }
}
