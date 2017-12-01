using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrabalhoFinal_Vendas.Infrastructure.Entity;
using TrabalhoFinal_Vendas.Infrastructure.Repository.Interfaces;

namespace TrabalhoFinal_Vendas.Infrastructure.Repository
{
    public class PrecoRepository : IPrecoRepository
    {
        private readonly AppContext _dbContext;

        public PrecoRepository(AppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            _dbContext.Preco.Remove(FindById(id));
            _dbContext.SaveChanges();
        }

        public IList<Preco> FindAll()
        {
            return _dbContext.Preco.ToList();
        }

        public Preco FindById(int id)
        {
            return _dbContext.Preco.FirstOrDefault(p => p.Id == id);
        }

        public Preco Save(Preco entity)
        {
            var preco = _dbContext.Preco.Add(entity);
            _dbContext.SaveChanges();

            return preco.Entity;
        }

        public Preco Update(Preco entity)
        {
            var preco = _dbContext.Preco.Update(entity);
            _dbContext.SaveChanges();

            return preco.Entity;
        }
    }
}
