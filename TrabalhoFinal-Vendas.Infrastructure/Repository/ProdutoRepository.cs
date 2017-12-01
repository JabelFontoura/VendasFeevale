using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrabalhoFinal_Vendas.Infrastructure.Entity;
using TrabalhoFinal_Vendas.Infrastructure.Repository.Interfaces;

namespace TrabalhoFinal_Vendas.Infrastructure.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppContext _dbContext;

        public ProdutoRepository(AppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            _dbContext.Produtos.Remove(FindById(id));
            _dbContext.SaveChanges();
        }

        public IList<Produto> FindAll()
        {
            return _dbContext.Produtos.ToList();
        }

        public Produto FindById(int id)
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
