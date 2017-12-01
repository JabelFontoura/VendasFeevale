﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrabalhoFinal_Vendas.Infrastructure.Entity;
using TrabalhoFinal_Vendas.Infrastructure.Repository.Interfaces;

namespace TrabalhoFinal_Vendas.Infrastructure.Repository
{
    public class CabecalhoVendaRepository : ICabecalhoVendaRepository
    {
        private readonly AppContext _db;

        public CabecalhoVendaRepository(AppContext dbContext)
        {
            _db = dbContext;
        }

        public void Delete(int id)
        {
            _db.CabVenda.Remove(FindById(id));
            _db.SaveChanges();
        }

        public IList<CabecalhoVenda> FindAll()
        {
            return _db.CabVenda.ToList();
        }

        public CabecalhoVenda FindById(int id)
        {
            return _db.CabVenda.FirstOrDefault(cv => cv.Id == id);
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
    }
}
