using System;
using System.Collections.Generic;
using System.Text;
using VendasFeevale.Infrastructure.Entity;

namespace VendasFeevale.Infrastructure.Repository.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario FindByLogin(string login);
    }
}
