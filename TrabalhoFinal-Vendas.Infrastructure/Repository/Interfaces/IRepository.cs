using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoFinal_Vendas.Infrastructure.Repository
{
    public interface IRepository<T>
    {
        IList<T> FindAll();
        T FindById(string id);
        T Save(T entity);
        void Delete(string id);
        T Update(T entity);
    }
}
