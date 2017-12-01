using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrabalhoFinal_Vendas.Infrastructure.Entity;
using TrabalhoFinal_Vendas.Infrastructure.Repository.Interfaces;

namespace TrabalhoFinal_Vendas.Infrastructure.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppContext _dbContext;

        public UsuarioRepository(AppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            var user = FindById(id);

            _dbContext.Usuario.Remove(user);
            _dbContext.SaveChanges();
        }

        public IList<Usuario> FindAll()
        {
            return _dbContext.Usuario.ToList();
        }

        public Usuario FindById(int id)
        {
            return _dbContext.Usuario.FirstOrDefault(u => u.Id == id);
        }

        public Usuario Save(Usuario entity)
        {
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
    }
}
