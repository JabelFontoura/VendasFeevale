using System;
using System.Collections.Generic;
using TrabalhoFinal_Vendas.Infrastructure.Entities.Enums;

namespace TrabalhoFinal_Vendas.Infrastructure.Entity
{
    public partial class Usuario
    {
        public Usuario()
        {
            CabVenda = new HashSet<CabecalhoVenda>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public Tipo Tipo { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public ICollection<CabecalhoVenda> CabVenda { get; set; }
    }
}
