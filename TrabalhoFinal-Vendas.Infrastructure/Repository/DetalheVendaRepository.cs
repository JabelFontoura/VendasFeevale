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
        private readonly AppContext _dbContext;

        public DetalheVendaRepository(AppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            _dbContext.DetVenda.Remove(FindById(id));
            _dbContext.SaveChanges();
        }

        public IList<DetalheVenda> FindAll()
        {
            return _dbContext.DetVenda.ToList();
        }

        public DetalheVenda FindById(int id)
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
