using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vendas.Infrastructure.Entity;
using Vendas.Infrastructure.Repository.Interfaces;

namespace Vendas.Infrastructure.Repository
{
    public class DetalheVendaRepository : IDetalheVendaRespository
    {
        private readonly AppDbContext _dbContext;

        public DetalheVendaRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(string id)
        {
            _dbContext.DetVenda.Remove(FindById(id));
            _dbContext.SaveChanges();
        }

        public IList<DetalheVenda> FindAll()
        {
            return HandleIncludes();
        }

        public DetalheVenda FindById(string id)
        {
            return HandleIncludes().FirstOrDefault(dv => dv.Id == id);
        }

        public DetalheVenda Save(DetalheVenda entity)
        {
            var detVenda = _dbContext.DetVenda.Add(entity);
            _dbContext.SaveChanges();

            return detVenda.Entity;
        }

        public DetalheVenda Update(DetalheVenda entity)
        {
            var detVenda = _dbContext.DetVenda.Update(entity);
            _dbContext.SaveChanges();

            return detVenda.Entity;
        }

        private IList<DetalheVenda> HandleIncludes()
        {
            return _dbContext.DetVenda
                .Include(d => d.CabecalhoVenda)
                .Include(d => d.Preco)
                .Include(d => d.Produto)
                .ToList();
        }
    }
}
