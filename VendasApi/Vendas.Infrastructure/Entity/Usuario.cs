using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Vendas.Infrastructure.Entities.Enums;

namespace Vendas.Infrastructure.Entity
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
        public string Senha { get; set; }
        public ICollection<CabecalhoVenda> CabVenda { get; set; }

        public string CriptografarSenha()
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.Default.GetBytes("5483@#$asdui109viu2%$*#$" + Senha);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("x2"));

            return sb.ToString();
        }
    }
}
