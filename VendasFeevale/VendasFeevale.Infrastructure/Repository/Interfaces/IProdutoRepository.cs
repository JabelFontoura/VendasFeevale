using System;
using System.Collections.Generic;
using System.Text;
using VendasFeevale.Infrastructure.Entity;

namespace VendasFeevale.Infrastructure.Repository.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Produto FindByIdCategoria(string id);
    }
}
