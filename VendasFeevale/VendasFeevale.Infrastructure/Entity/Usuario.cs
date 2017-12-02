using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using VendasFeevale.Infrastructure.Entities.Enums;

namespace VendasFeevale.Infrastructure.Entity
{
    public partial class Usuario
    {
        public Usuario()
        {
            CabVenda = new HashSet<CabecalhoVenda>();
        }

        public string Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public Tipo Tipo { get; set; }
        public string Nome { get; set; }
        public string Senha
        { 
            get
            {
                return Senha;
            }
            set
            {
                Senha = CriptografarSenha(Senha);
            }
        }
        public ICollection<CabecalhoVenda> CabVenda { get; set; }

        private string CriptografarSenha(string senha)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.Default.GetBytes(Email + senha);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("x2"));

            return sb.ToString();
        }
    }
}
