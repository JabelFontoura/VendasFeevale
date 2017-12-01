using System;
using System.Collections.Generic;
using TrabalhoFinal_Vendas.Infrastructure.Entities.Enums;

namespace TrabalhoFinal_Vendas.Infrastructure.Entity
{
    public partial class CabecalhoVenda
    {
        public CabecalhoVenda()
        {
            DetVenda = new HashSet<DetalheVenda>();
        }

        public int Id { get; set; }
        public int IdCliente { get; set; }
        public DateTime Data { get; set; }
        public string Hora { get; set; }
        public Situacao Situacao { get; set; }
        public DateTime DataExpedicao { get; set; }
        public DateTime DataAceite { get; set; }

        public Usuario IdClienteNavigation { get; set; }
        public ICollection<DetalheVenda> DetVenda { get; set; }
    }
}
