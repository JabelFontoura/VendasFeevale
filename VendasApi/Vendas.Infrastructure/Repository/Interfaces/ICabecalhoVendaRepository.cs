using System;
using System.Collections.Generic;
using System.Text;
using Vendas.Infrastructure.Entities.Enums;
using Vendas.Infrastructure.Entity;

namespace Vendas.Infrastructure.Repository.Interfaces
{
    public interface ICabecalhoVendaRepository : IRepository<CabecalhoVenda>
    {
        CabecalhoVenda FindByIdUsuarioAndStatus(string id, Situacao situacao);
        IList<CabecalhoVenda> FindByIdUsuario(string id);
    }
}
