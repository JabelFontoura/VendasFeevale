using System;
using System.Collections.Generic;

namespace TrabalhoFinal_Vendas.Infrastructure.Entity
{
    public partial class Preco
    {
        public Preco()
        {
            DetVenda = new HashSet<DetalheVenda>();
        }

        public int Id { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
        public int IdProduto { get; set; }
        public DateTime? DataValidade { get; set; }

        public Produto IdProdutoNavigation { get; set; }
        public ICollection<DetalheVenda> DetVenda { get; set; }
    }
}
