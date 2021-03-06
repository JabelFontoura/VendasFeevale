﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Vendas.Infrastructure.Entity
{
    public partial class Categoria
    {
        public Categoria()
        {
            Produtos = new HashSet<Produto>();
        }

        public string Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
