using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendasFeevale.Infrastructure.Entity;
using VendasFeevale.Infrastructure.Repository.Interfaces;

namespace VendasFeevale.Infrastructure.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _dbContext;

        public ProdutoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(string id)
        {
            _dbContext.Produtos.Remove(FindById(id));
            _dbContext.SaveChanges();
        }

        public IList<Produto> FindAll()
        {
            return _dbContext.Produtos.ToList();
        }

        public Produto FindById(string id)
        {
            return _dbContext.Produtos.FirstOrDefault(p => p.Id == id);
        }

        public Produto Save(Produto entity)
        {
            var produto = _dbContext.Produtos.Add(entity);
            _dbContext.SaveChanges();

            return produto.Entity;
        }

        public Produto Update(Produto entity)
        {
            var produto = _dbContext.Update(entity);

            return produto.Entity;
        }
    }
}
