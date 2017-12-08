using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vendas.Infrastructure.Entity;
using Vendas.Infrastructure.Repository.Interfaces;

namespace Vendas.Infrastructure.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _dbContext;

        public UsuarioRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(string id)
        {
            var user = FindById(id);

            _dbContext.Usuario.Remove(user);
            _dbContext.SaveChanges();
        }

        public IList<Usuario> FindAll()
        {
            return HandleIncludes().ToList();
        }

        public Usuario FindById(string id)
        {
            return HandleIncludes().FirstOrDefault(u => u.Id == id);
        }

        public Usuario FindByLogin(string login)
        {
            return HandleIncludes().FirstOrDefault(u => u.Login == login);
        }

        public Usuario Save(Usuario entity)
        {
            entity.Senha = entity.CriptografarSenha();

            var user = _dbContext.Usuario.Add(entity);
            _dbContext.SaveChanges();

            return user.Entity;
        }

        public Usuario Update(Usuario entity)
        {
            var user = _dbContext.Usuario.Update(entity);
            _dbContext.SaveChanges();

            return user.Entity;
        }

        private IList<Usuario> HandleIncludes()
        {
            return _dbContext.Usuario
                .Include(u => u.CabecalhoVenda)
                .ToList();
        }
    }
}
