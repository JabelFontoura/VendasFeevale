using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Vendas.Infrastructure.Entity
{
    public partial class DetalheVenda
    {
        public string Id { get; set; }

        public virtual CabecalhoVenda CabecalhoVenda { get; set; }
        public virtual Preco Preco { get; set; }

        public virtual Produto Produto { get; set; }
        public virtual string IdCabecalhoVenda { get; set; }
        public virtual string IdPreco { get; set; }
        public virtual string IdProduto { get; set; }
    }
}
