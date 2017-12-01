using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoFinal_Vendas.Infrastructure.Repository
{
    public interface IRepository<T>
    {
        IList<T> FindAll();
        T FindById(int id);
        T Save(T entity);
        void Delete(int id);
        T Update(T entity);
    }
}
