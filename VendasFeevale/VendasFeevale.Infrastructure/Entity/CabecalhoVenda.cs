using System;
using System.Collections.Generic;
using VendasFeevale.Infrastructure.Entities.Enums;

namespace VendasFeevale.Infrastructure.Entity
{
    public partial class CabecalhoVenda
    {
        public CabecalhoVenda()
        {
            DetVenda = new HashSet<DetalheVenda>();
        }

        public string Id { get; set; }
        public string IdCliente { get; set; }
        public DateTime Data { get; set; }
        public string Hora { get; set; }
        public Situacao Situacao { get; set; }
        public DateTime DataExpedicao { get; set; }
        public DateTime? DataAceite { get; set; }

        public Usuario IdClienteNavigation { get; set; }
        public ICollection<DetalheVenda> DetVenda { get; set; }
    }
}
