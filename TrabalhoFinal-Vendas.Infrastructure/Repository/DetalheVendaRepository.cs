using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrabalhoFinal_Vendas.Infrastructure.Entity;
using TrabalhoFinal_Vendas.Infrastructure.Repository.Interfaces;

namespace TrabalhoFinal_Vendas.Infrastructure.Repository
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
            return _dbContext.DetVenda.ToList();
        }

        public DetalheVenda FindById(string id)
        {
            return _dbContext.DetVenda.FirstOrDefault(dv => dv.Id == id);
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
    }
}
