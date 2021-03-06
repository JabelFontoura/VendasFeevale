﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vendas.Infrastructure.Entity;
using Vendas.Infrastructure.Repository.Interfaces;

namespace Vendas.Infrastructure.Repository
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
            return HandleIncludes();
        }

        public Preco FindById(string id)
        {
            return HandleIncludes().FirstOrDefault(p => p.Id == id);
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

        private IList<Preco> HandleIncludes()
        {
            return _dbContext.Preco
                .Include(p => p.Produto)
                .Include(p => p.DetalheVendas)
                .ToList();
        }
    }
}
