using System;
using System.Collections.Generic;

namespace TrabalhoFinal_Vendas.Infrastructure.Entity
{
    public partial class Produto
    {
        public Produto()
        {
            DetVenda = new HashSet<DetalheVenda>();
            Preco = new HashSet<Preco>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdCategoria { get; set; }

        public Categoria IdCategoriaNavigation { get; set; }
        public ICollection<DetalheVenda> DetVenda { get; set; }
        public ICollection<Preco> Preco { get; set; }
    }
}
