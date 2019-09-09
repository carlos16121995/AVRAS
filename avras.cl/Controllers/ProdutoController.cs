using System;
using System.Collections.Generic;
using System.Text;
using avras.cl.ViewModels;
using avras.cl.Models;
using System.Linq;

namespace avras.cl.Controllers
{
    public class ProdutoController
    {
        public ProdutoViewModel BuscarProdutosPorId(int id, bool includeCategoria = false)
        {
            var produto = new Produto().BuscarProdutosPorId(id);
            return new ProdutoViewModel()
            {
                Id = produto.Id,
                Nome = produto.Nome,
                ValorVenda = produto.ValorVenda,
                Estoque = produto.Estoque,
                EstoqueMinimo = produto.EstoqueMinimo,
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
                            ValorVenda = p.ValorVenda,
                            Estoque = p.Estoque,
                            EstoqueMinimo = p.EstoqueMinimo,
                            CategoriaId = p.CategoriaId,
                            Categoria = (includeCategoria == true ? BuscarCategoriaPorId(p.CategoriaId) : null),
                            Disponível = p.Disponível,
                        }).ToList();
            else
                return null;
        }
        public List<ProdutoViewModel> BuscarProdutos(bool includeCategoria = false)
        {
            var produtos = new Produto().BuscarProdutos();
            if (produtos != null && produtos.Count > 0)

                return (from produto in produtos
                        select new ProdutoViewModel()
                        {
                            Id = produto.Id,
                            Nome = produto.Nome,
                            ValorVenda = produto.ValorVenda,
                            Estoque = produto.Estoque,
                            EstoqueMinimo = produto.EstoqueMinimo,
                            CategoriaId = produto.CategoriaId,
                            Categoria = (includeCategoria == true ? BuscarCategoriaPorId(produto.CategoriaId) : null),
                            Disponível = produto.Disponível,
                        }).ToList();
            else
                return null;
        }
        public int Gravar(ProdutoViewModel p)
        {
            int result;

            Produto produto = new Produto()
            {
                Id = p.Id,
                Nome = p.Nome,
                ValorVenda = p.ValorVenda,
                Estoque = p.Estoque,
                EstoqueMinimo = p.EstoqueMinimo,
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
                ValorVenda = p.ValorVenda,
                Estoque = p.Estoque,
                EstoqueMinimo = p.EstoqueMinimo,
                CategoriaId = p.CategoriaId,
                Disponível = p.Disponível,
            };
            return produto.Alterar();
        }
        public int Excluir(int id)
        {
            return new Produto().Excluir(id);
        }

        // Tipos e Categorias
        public List<TipoProdutoViewModel> Listar()
        {
            var categorias = new Models.TipoProduto().BuscarTipoProduto();
            if (categorias != null && categorias.Count > 0)

                return (from categoria in categorias
                        select new TipoProdutoViewModel()
                        {
                            Id = categoria.Id,
                            Nome = categoria.Nome,
                            SrcImagem = categoria.SrcImagem,
                        }).ToList();
            else
                return null;
        }


        public TipoProdutoViewModel BuscarCategoriaPorId(int id)
        {
            var categoria = new Models.TipoProduto().BuscarTipoProdutoPorId(id);
            return new TipoProdutoViewModel()
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                SrcImagem = categoria.SrcImagem,
            };
        }
        public int Gravar(TipoProdutoViewModel p)
        {
            int result;

            Models.TipoProduto TipoProduto = new Models.TipoProduto()
            {
                Nome = p.Nome,
                SrcImagem = p.SrcImagem,
            };

            if (p.Id != 0)
            {
                TipoProduto.Id = p.Id;
                result = TipoProduto.Alterar();
            }
            else
            {
                result = TipoProduto.Gravar();
            }

            return result;
        }
        public int Alterar(TipoProdutoViewModel p)
        {
            Models.TipoProduto TipoProduto = new Models.TipoProduto()
            {
                Id = p.Id,
                Nome = p.Nome,
                SrcImagem = p.SrcImagem,
            };
            return TipoProduto.Alterar();
        }
        public int ExcluirTipoProduto(int id)
        {
            return new Models.TipoProduto().Excluir(id);
        }


    }
}
