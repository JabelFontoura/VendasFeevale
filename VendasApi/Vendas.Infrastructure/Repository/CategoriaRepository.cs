﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vendas.Infrastructure.Entity;
using Vendas.Infrastructure.Repository.Interfaces;

namespace Vendas.Infrastructure.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _dbContext;

        public CategoriaRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(string id)
        {
            _dbContext.Categoria.Remove(FindById(id));
            _dbContext.SaveChanges();
        }

        public IList<Categoria> FindAll()
        {
            return HandleIncludes();
        }

        public Categoria FindById(string id)
        {
            return HandleIncludes().FirstOrDefault(c => c.Id == id);
        }

        public Categoria FindByNome(string nome)
        {
            return HandleIncludes().FirstOrDefault(c => c.Nome == nome);
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

        private IList<Categoria> HandleIncludes()
        {
            return _dbContext.Categoria
                .Include(c => c.Produtos)
                .ToList();
        }
    }
}
