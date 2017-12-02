using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendasFeevale.Infrastructure.Entity;
using VendasFeevale.Infrastructure.Repository.Interfaces;

namespace VendasFeevale.Infrastructure.Repository
{
    public class PrecoRepository : IPrecoRepository
    {
        private readonly AppDbContext _dbContext;

        public PrecoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(string id)
        {
            _dbContext.Preco.Remove(FindById(id));
            _dbContext.SaveChanges();
        }

        public IList<Preco> FindAll()
        {
            return _dbContext.Preco.ToList();
        }

        public Preco FindById(string id)
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
