using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vendas.Infrastructure.Entities.Enums;
using Vendas.Infrastructure.Entity;
using Vendas.Infrastructure.Repository.Interfaces;

namespace Vendas.Infrastructure.Repository
{
    public class CabecalhoVendaRepository : ICabecalhoVendaRepository
    {
        private readonly AppDbContext _db;

        public CabecalhoVendaRepository(AppDbContext dbContext)
        {
            _db = dbContext;
        }

        public void Delete(string id)
        {
            _db.CabVenda.Remove(FindById(id));
            _db.SaveChanges();
        }

        public IList<CabecalhoVenda> FindAll()
        {
            return HandleIncludes();
        }

        public CabecalhoVenda FindById(string id)
        {
            return HandleIncludes().FirstOrDefault(cv => cv.Id == id);
        }

        public CabecalhoVenda FindByIdUsuarioAndStatus(string id, Situacao situacao)
        {
            return HandleIncludes().FirstOrDefault(cv => cv.IdUsuario == id && cv.Situacao == situacao);
        }

        public IList<CabecalhoVenda> FindByIdUsuario(string id)
        {
            return HandleIncludes().Where(cv => cv.IdUsuario == id).ToList();
        }

        public CabecalhoVenda Save(CabecalhoVenda entity)
        {
            var cabecalhoVenda = _db.CabVenda.Add(entity);
            _db.SaveChanges();

            return cabecalhoVenda.Entity;
        }

        public CabecalhoVenda Update(CabecalhoVenda entity)
        {
            var cabecalhoVenda = _db.CabVenda.Update(entity);
            _db.SaveChanges();

            return cabecalhoVenda.Entity;
        }

        private IList<CabecalhoVenda> HandleIncludes()
        {
            return _db.CabVenda
                .Include(c => c.Usuario)
                .Include(c => c.DetalheVendas)
                .ToList();
        }
    }
}
