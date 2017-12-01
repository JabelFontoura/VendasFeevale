using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrabalhoFinal_Vendas.Infrastructure.Entity;
using TrabalhoFinal_Vendas.Infrastructure.Repository.Interfaces;

namespace TrabalhoFinal_Vendas.Infrastructure.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppContext _dbContext;

        public CategoriaRepository(AppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            _dbContext.Categoria.Remove(FindById(id));
            _dbContext.SaveChanges();
        }

        public IList<Categoria> FindAll()
        {
            return _dbContext.Categoria.ToList();
        }

        public Categoria FindById(int id)
        {
            return _dbContext.Categoria.FirstOrDefault(c => c.Id == id);
        }

        public Categoria Save(Categoria entity)
        {
            var categoria = _dbContext.Categoria.Add(entity);
            _dbContext.SaveChanges();

            return categoria.Entity;
        }

        public Categoria Update(Categoria entity)
        {
            var categoria = _dbContext.Categoria.Update(entity);
            _dbContext.SaveChanges();

            return categoria.Entity;
        }
    }
}
