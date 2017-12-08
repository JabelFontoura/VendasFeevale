using System;
using System.Collections.Generic;
using Vendas.Infrastructure.Entities.Enums;

namespace Vendas.Infrastructure.Entity
{
    public partial class CabecalhoVenda
    {
        public CabecalhoVenda()
        {
            DetalheVendas = new HashSet<DetalheVenda>();
        }

        public string Id { get; set; }
        public DateTime Data { get; set; }
        public string Hora { get; set; }
        public Situacao Situacao { get; set; }
        public DateTime DataExpedicao { get; set; }
        public DateTime? DataAceite { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<DetalheVenda> DetalheVendas { get; set; }
        public virtual string IdUsuario { get; set; }
    }
}
