using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vendas.Infrastructure.Entity;
using Vendas.Infrastructure.Repository.Interfaces;

namespace Vendas.Infrastructure.Repository
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
            return HandleInclues();
        }

        public Produto FindById(string id)
        {
            return HandleInclues().FirstOrDefault(p => p.Id == id);
        }

        public Produto FindByIdCategoria(string id)
        {
            return HandleInclues().FirstOrDefault(p => p.Categoria.Id == id);
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

        private IList<Produto> HandleInclues()
        {
            return _dbContext.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.DetalheVendas)
                .Include(p => p.Preco).ToList();
        }
    }
}
