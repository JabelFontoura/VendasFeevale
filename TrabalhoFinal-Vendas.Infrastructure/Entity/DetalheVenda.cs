using System;
using System.Collections.Generic;

namespace TrabalhoFinal_Vendas.Infrastructure.Entity
{
    public partial class DetalheVenda
    {
        public int Id { get; set; }
        public int IdCab { get; set; }
        public int IdProduto { get; set; }
        public int IdPreco { get; set; }

        public CabecalhoVenda IdCabNavigation { get; set; }
        public Preco IdPrecoNavigation { get; set; }
        public Produto IdProdutoNavigation { get; set; }
    }
}
