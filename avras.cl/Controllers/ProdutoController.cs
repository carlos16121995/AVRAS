﻿using System;
using System.Collections.Generic;
using System.Text;
using avras.cl.ViewModels;
using avras.cl.Models;
using System.Linq;

namespace avras.cl.Controllers
{
    public class ProdutoController
    {
        public List<ProdutoCategoriaViewModel> Listar()
        {
            var categorias = new ProdutoCategoria().BuscarCategorias();
            if (categorias != null && categorias.Count > 0)

                return (from categoria in categorias
                        select new ProdutoCategoriaViewModel()
                        {
                            Id = categoria.Id,
                            Nome = categoria.Nome,
                            Descricao = categoria.Descricao,
                        }).ToList();
            else
                return null;
        }
        public int Gravar(ProdutoViewModel p)
        {
            int result;

            Produto produto = new Produto()
            {
                Nome = p.Nome,
                ValorCompra = p.ValorCompra,
                ValorVenda = p.ValorVenda,
                Quantidade = p.Quantidade,
                QuantidadeMinima = p.QuantidadeMinima,
                CategoriaId = p.CategoriaId,
                Disponível = p.Disponível,
            };

            if (p.Id != 0)
            {
                produto.Id = p.Id;
                result = produto.Alterar();
            }
            else
            {
                result = produto.Gravar();
            }

            return result;
        }
        public int Alterar(ProdutoViewModel p)
        {
            Produto produto = new Produto()
            {
                Id = p.Id,
                Nome = p.Nome,
                ValorCompra = p.ValorCompra,
                ValorVenda = p.ValorVenda,
                Quantidade = p.Quantidade,
                QuantidadeMinima = p.QuantidadeMinima,
                CategoriaId = p.CategoriaId,
                Disponível = p.Disponível,
            };
            return  produto.Alterar();
        }
        public List<ProdutoViewModel> BuscarProdutos(bool includeCategoria = false)
        {
            var produtos = new Produto().BuscarProdutos();
            if (produtos != null && produtos.Count > 0)

                return (from p in produtos
                        select new ProdutoViewModel()
                        {
                            Id = p.Id,
                            Nome = p.Nome,
                            ValorCompra = p.ValorCompra,
                            ValorVenda = p.ValorVenda,
                            Quantidade = p.Quantidade,
                            QuantidadeMinima = p.QuantidadeMinima,
                            Categoria = (includeCategoria == true ? BuscarCategoriaPorId(p.CategoriaId) : null),
                            Disponível = p.Disponível,
                        }).ToList();
            else
                return null;
        }
        private ProdutoCategoriaViewModel BuscarCategoriaPorId(int id)
        {
            var categoria = new ProdutoCategoria().BuscarCategoriaPorId(id);
            return new ProdutoCategoriaViewModel()
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                Descricao = categoria.Descricao,
            };
        }
        public int Excluir(int id)
        {
            return new Produto().Excluir(id);
        }
        public ProdutoViewModel BuscarProdutosPorId(int id, bool includeCategoria = false) {
            var produto = new Produto().BuscarProdutosPorId(id);
            return new ProdutoViewModel()
            {
                Id = produto.Id,
                Nome = produto.Nome,
                ValorCompra = produto.ValorCompra,
                ValorVenda = produto.ValorVenda,
                Quantidade = produto.Quantidade,
                QuantidadeMinima = produto.QuantidadeMinima,
                CategoriaId = produto.CategoriaId,
                Categoria = (includeCategoria == true ? BuscarCategoriaPorId(produto.CategoriaId) : null),
                Disponível = produto.Disponível,
            };
        }
        public List<ProdutoViewModel> BuscarProdutoPorNome(string nome, bool includeCategoria = false)
        {
            var produtos = new Produto().BuscarProdutosPorNome(nome);
            if (produtos != null && produtos.Count > 0)

                return (from p in produtos
                        select new ProdutoViewModel()
                        {
                            Id = p.Id,
                            Nome = p.Nome,
                            ValorCompra = p.ValorCompra,
                            ValorVenda = p.ValorVenda,
                            Quantidade = p.Quantidade,
                            QuantidadeMinima = p.QuantidadeMinima,
                            Categoria = (includeCategoria == true ? BuscarCategoriaPorId(p.CategoriaId) : null),
                            Disponível = p.Disponível,
                        }).ToList();
            else
                return null;
        }
    }
}