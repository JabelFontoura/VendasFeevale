using System;
using System.Collections.Generic;

namespace VendasFeevale.Infrastructure.Entity
{
    public partial class Preco
    {
        public Preco()
        {
            DetVenda = new HashSet<DetalheVenda>();
        }

        public string Id { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
        public string IdProduto { get; set; }
        public DateTime? DataValidade { get; set; }

        public Produto IdProdutoNavigation { get; set; }
        public ICollection<DetalheVenda> DetVenda { get; set; }
    }
}
