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
                using (avrasContext contexto = new avrasContext())
                {
                    if (produto.Id == 0)
                    {
                        contexto.Produto.Add(produto);
                    }
                    else
                    {
                        contexto.Produto.Attach(produto);

                    }
                    return contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        internal int Alterar(Produto palterado)
        {
            try
            {
                using (avrasContext contexto = new avrasContext())
                {
                    var patual = contexto.Produto.Where(p => p.Id == palterado.Id).FirstOrDefault();
                    patual.Nome = palterado.Nome;
                    patual.ValorVenda = palterado.ValorVenda;
                    
                    patual.Estoque = palterado.Estoque;
                    patual.EstoqueMinimo = palterado.EstoqueMinimo;
                    patual.CategoriaId = palterado.CategoriaId;
                    patual.Disponível = palterado.Disponível;



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
                using (avrasContext contexto = new avrasContext())
                {
                    return contexto.Produto.Find(id);
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
                using (avrasContext contexto = new avrasContext())
                {
                    nome = "%" + nome + "%";
                    return (from p in contexto.Produto
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
                using (avrasContext contexto = new avrasContext())
                {
                    return contexto.Produto.OrderBy(p => p.Nome).ToList();
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
                using (avrasContext contexto = new avrasContext())
                {
                    var produto = contexto.Produto.Where(p => p.Id == id).FirstOrDefault();
                    if (produto != null)
                    {
                        contexto.Produto.Remove(produto);
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
