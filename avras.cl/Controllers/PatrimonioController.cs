using System;
using System.Collections.Generic;
using System.Text;
using avras.cl.ViewModels;
using avras.cl.Models;
using System.Linq;

namespace avras.cl.Controllers
{
    class PatrimonioController
    {
        //public List<PatrimonioTipoViewModel> Listar()
        //{
        //    var categorias = new PatrimonioTipo().BuscarCategorias();
        //    if (categorias != null && categorias.Count > 0)

        //        return (from categoria in categorias
        //                select new ProdutoCategoriaViewModel()
        //                {
        //                    Id = categoria.Id,
        //                    Nome = categoria.Nome,
        //                    Descricao = categoria.Descricao,
        //                }).ToList();
        //    else
        //        return null;
        //}
        public int Gravar(PatrimonioViewModel p)
        {
            int result;

            Patrimonio patrimonio = new Patrimonio()
            {
                Nome = p.Nome,
                Descicao = p.Descicao,
                Quantidade = p.Quantidade,
                ValorCompra = p.ValorCompra,
                ValorPerda = p.ValorPerda,
                Disponibilidade = p.Disponibilidade,
                Anotacao = p.Anotacao,
                DataAquisicao = p.DataAquisicao,
                DataPerda = p.DataPerda,
                TipoPatrimonioId = p.TipoPatrimonioId,
            };

            if (p.Id != 0)
            {
                patrimonio.Id = p.Id;
                result = patrimonio.Alterar();
            }
            else
            {
                result = patrimonio.Gravar();
            }

            return result;
        }
        public int Alterar(PatrimonioViewModel p)
        {
            Patrimonio patrimonio = new Patrimonio()
            {
                Id = p.Id,
                Nome = p.Nome,
                Descicao = p.Descicao,
                Quantidade = p.Quantidade,
                ValorCompra = p.ValorCompra,
                ValorPerda = p.ValorPerda,
                Disponibilidade = p.Disponibilidade,
                Anotacao = p.Anotacao,
                DataAquisicao = p.DataAquisicao,
                DataPerda = p.DataPerda,
                TipoPatrimonioId = p.TipoPatrimonioId,
            };
            return patrimonio.Alterar();
        }
        public List<PatrimonioViewModel> BuscarProdutos(bool includeTipo = false)
        {
            var patrimonios = new Patrimonio().BuscarPatrimonios();
            if (patrimonios != null && patrimonios.Count > 0)

                return (from p in patrimonios
                        select new PatrimonioViewModel()
                        {
                            Id = p.Id,
                            Nome = p.Nome,
                            Descicao = p.Descicao,
                            Quantidade = p.Quantidade,
                            ValorCompra = p.ValorCompra,
                            ValorPerda = p.ValorPerda,
                            Disponibilidade = p.Disponibilidade,
                            Anotacao = p.Anotacao,
                            DataAquisicao = p.DataAquisicao,
                            DataPerda = p.DataPerda,
                            TipoPatrimonioId = p.TipoPatrimonioId,
                            TipoPatrimonio = (includeTipo == true ? BuscarTipoPorId(p.TipoPatrimonioId) : null),
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
        public ProdutoViewModel BuscarProdutosPorId(int id, bool includeCategoria = false)
        {
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
        public List<ProdutoViewModel> BuscarTipoPorId(string nome, bool includeCategoria = false)
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
