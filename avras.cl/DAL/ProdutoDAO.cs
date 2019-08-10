using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using avras.cl.Models;
using Microsoft.EntityFrameworkCore;

namespace avras.cl.DAL
{
    internal class ProdutoDAO
    {
        internal int Gravar(Produto produto)
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    if (produto.Id == 0)
                    {
                        contexto.TipoProduto.Add(produto);
                    }
                    else
                    {
                        contexto.TipoProduto.Attach(produto);

                    }
                    return contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        internal int Alterar(Produto pAlterado)
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    var pAtual = contexto.TipoProduto.Where(p => p.Id == pAlterado.Id).Include("Categoria").FirstOrDefault();
                    pAtual.Nome = pAlterado.Nome;
                    pAtual.ValorVenda = pAlterado.ValorVenda;
                    pAtual.ValorCompra = pAlterado.ValorCompra;
                    pAtual.Quantidade = pAlterado.Quantidade;
                    pAtual.QuantidadeMinima = pAlterado.QuantidadeMinima;
                    pAtual.CategoriaId = pAlterado.CategoriaId;
                    pAtual.Disponível = pAlterado.Disponível;
                   


                    return contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        internal Produto BuscarProdutosPorId(int id)
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    return contexto.TipoProduto.Find(id);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        internal List<Produto> BuscarProdutosPorNome(string nome)
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    nome = "%" + nome + "%";
                    return (from p in contexto.TipoProduto
                            where EF.Functions.Like(p.Nome, nome)
                            select p).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        internal List<Produto> BuscarProdutos()
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    return contexto.TipoProduto.OrderBy(p => p.Nome).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        internal int Excluir(int id)
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    var produto = contexto.TipoProduto.Where(p => p.Id == id).FirstOrDefault();
                    if (produto != null)
                    {
                        contexto.TipoProduto.Remove(produto);
                        return contexto.SaveChanges();
                    }
                    else
                        return 0;
                }
            }
            catch
            {
                return -1;
            }
        }

    }
}
