using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vendas.Infrastructure.Entities.Enums;
using Vendas.Infrastructure.Entity;
using Vendas.Infrastructure.Repository.Interfaces;

namespace Vendas.Infrastructure
{
    public static class DbInitializer
    {

        public static void Initialize(AppDbContext context, IUsuarioRepository usuarioRepository, ICategoriaRepository categoriaRepository, IProdutoRepository produtoRepository)
        {
            context.Database.EnsureCreated();

            InitializeUsuarios(context, usuarioRepository);
            InitializeCategorias(context, categoriaRepository);
            InitializeProdutos(context, produtoRepository, categoriaRepository);
        }

        private static void InitializeUsuarios(AppDbContext context, IUsuarioRepository usuarioRepository)
        {
            if (context.Usuario.Any())
                return;

            var usuarios = new Usuario[]
            {
                new Usuario(){ Email = "usuario.admin@mail.com", Login = "admin", Nome = "Usuário Admin", Senha = "admin", Tipo = Tipo.Admin },
                new Usuario(){ Email = "usuario.comum@mail.com", Login = "comum", Nome = "Usuário Comum", Senha = "comum", Tipo = Tipo.Comum }
            };

            foreach (var u in usuarios)
                usuarioRepository.Save(u);
        }

        private static void InitializeCategorias(AppDbContext context, ICategoriaRepository categoriaRepository)
        {
            if (context.Categoria.Any())
                return;

            var categorias = new Categoria[]
            {
                new Categoria(){ Nome = "Eletônico" },
                new Categoria(){ Nome = "Game" },
                new Categoria(){ Nome = "Instrumento Musical" }
            };

            foreach (var c in categorias)
                categoriaRepository.Save(c);
        }

        private static void InitializeProdutos(AppDbContext context, IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository)
        {
            if (context.Produtos.Any())
                return;

            var produtos = new Produto[]
            {
                new Produto(){
                    Nome = "Smartphone Quantum MÜV",
                    UrlImagem = "https://imgmanagercb-a.akamaihd.net/celular-e-smartphone/smartphone-quantum-muv_200x200-PU980f9_1.jpg",
                    IdCategoria = categoriaRepository.FindByNome("Eletônico").Id,
                    Preco = new Preco[]
                    {
                        new Preco(){ Data = DateTime.Now, Valor = 399.90 }
                    }
                },
                new Produto(){
                    Nome = "Asus Zenfone 2 Ze551ml 64gb Dual Prata",
                    UrlImagem = "https://images-americanas.b2w.io/produtos/01/00/sku/25250/7/25250763_1GG.jpg",
                    IdCategoria = categoriaRepository.FindByNome("Eletônico").Id,
                    Preco = new Preco[]
                    {
                        new Preco(){ Data = DateTime.Now, Valor = 799.79 }
                    }
                },
                new Produto(){
                    Nome = "Game - The Witcher III Wild Hunt: Edição Completa - PS4",
                    UrlImagem = "https://images-submarino.b2w.io/produtos/01/00/item/128877/4/128877477_1GG.jpg",
                    IdCategoria = categoriaRepository.FindByNome("Game").Id,
                    Preco = new Preco[]
                    {
                        new Preco(){ Data = DateTime.Now, Valor = 99.99 }
                    }
                },
                new Produto(){
                    Nome = "Game - The Last Of Us Remasterizado - PS4",
                    UrlImagem = "https://images-submarino.b2w.io/produtos/01/00/item/119572/9/119572911_1GG.png",
                    IdCategoria = categoriaRepository.FindByNome("Game").Id,
                    Preco = new Preco[]
                    {
                        new Preco(){ Data = DateTime.Now, Valor = 99.99 }
                    }
                },
                new Produto(){
                    Nome = "Guitarra Strato Fender 64 Stratocaster Anniversary Closet Classic",
                    UrlImagem = "http://www.playtech.com.br/Imagens/produtos/72/480772/480772_Ampliada.jpg",
                    IdCategoria = categoriaRepository.FindByNome("Instrumento Musical").Id,
                    Preco = new Preco[]
                    {
                        new Preco(){ Data = DateTime.Now, Valor = 25894.80 }
                    }
                },
                new Produto(){
                    Nome = "Guitarra Les Paul Epiphone Custom Classic",
                    UrlImagem = "http://www.playtech.com.br/Imagens/produtos/49/242349/242349_Ampliada.jpg",
                    IdCategoria = categoriaRepository.FindByNome("Instrumento Musical").Id,
                    Preco = new Preco[]
                    {
                        new Preco(){ Data = DateTime.Now, Valor = 4307.40 }
                    }
                }
            };

            foreach (var p in produtos)
                produtoRepository.Save(p);
        }
    }
}
