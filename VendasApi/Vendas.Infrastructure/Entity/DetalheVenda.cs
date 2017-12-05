using System;
using System.Collections.Generic;

namespace Vendas.Infrastructure.Entity
{
    public partial class DetalheVenda
    {
        public string Id { get; set; }
        public string IdCab { get; set; }
        public string IdProduto { get; set; }
        public string IdPreco { get; set; }

        public CabecalhoVenda IdCabNavigation { get; set; }
        public Preco IdPrecoNavigation { get; set; }
        public Produto IdProdutoNavigation { get; set; }
    }
}
