using System;
using System.Collections.Generic;

namespace TrabalhoFinal_Vendas.Infrastructure.Entity
{
    public partial class Categoria
    {
        public Categoria()
        {
            Produtos = new HashSet<Produto>();
        }

        public string Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}
