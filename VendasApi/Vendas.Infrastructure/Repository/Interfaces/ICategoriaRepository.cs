using System;
using System.Collections.Generic;
using System.Text;
using Vendas.Infrastructure.Entity;

namespace Vendas.Infrastructure.Repository.Interfaces
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Categoria FindByNome(string nome);
    }
}
