using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using avras.cl.Models;
namespace avras.cl.DAL
{
    internal class ProdutoCategoriaDAO
    {
        internal int Gravar(ProdutoCategoria produtoCategoria)
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    if (produtoCategoria.Id == 0)
                    {
                        contexto.ProdutoCategoria.Add(produtoCategoria);
                    }
                    else
                    {
                        contexto.ProdutoCategoria.Attach(produtoCategoria);

                    }
                    return contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        internal ProdutoCategoria BuscarCategoriaPorId(int id)
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    return contexto.ProdutoCategoria.Find(id);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        internal List<ProdutoCategoria> BuscarCategorias()
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    return contexto.ProdutoCategoria.OrderBy(p => p.Nome).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /*internal int Alterar(ProdutoCategoria pAlterado)
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    var pAtual = contexto.ProdutoCategoria.Where(p => p.Id == pAlterado.Id).FirstOrDefault();
                    pAtual.Nome = pAlterado.Nome;
                    pAtual.DataCadastro = pAlterado.DataCadastro;
                    pAtual.Valor = pAlterado.Valor;
                    pAtual.DataVencimento = pAlterado.DataVencimento;
                    pAtual.Parcelas = pAlterado.Parcelas;
                    return contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }*/
    }
}
