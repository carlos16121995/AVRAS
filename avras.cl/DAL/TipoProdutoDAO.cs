using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using avras.cl.Models;
namespace avras.cl.DAL
{
    internal class TipoProdutoDAO
    {
        internal int Gravar(TipoProduto TipoProduto)
        {
            try
            {
                using (avrasContext contexto = new avrasContext())
                {
                    if (TipoProduto.Id == 0)
                    {
                        contexto.TipoProduto.Add(TipoProduto);
                    }
                    else
                    {
                        contexto.TipoProduto.Attach(TipoProduto);

                    }
                    return contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        internal TipoProduto BuscarCategoriaPorId(int id)
        {
            try
            {
                using (avrasContext contexto = new avrasContext())
                {
                    return contexto.TipoProduto.Find(id);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        internal List<TipoProduto> BuscarCategorias()
        {
            try
            {
                using (avrasContext contexto = new avrasContext())
                {
                    return contexto.TipoProduto.OrderBy(p => p.Nome).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        internal int Alterar(TipoProduto ptAlterado)
        {
            try
            {
                using (avrasContext contexto = new avrasContext())
                {
                    var pAtual = contexto.TipoProduto.Where(p => p.Id == ptAlterado.Id).FirstOrDefault();
                    pAtual.Nome = ptAlterado.Nome;
                    pAtual.SrcImagem = ptAlterado.SrcImagem;
                    return contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        internal int Excluir(int id)
        {
            try
            {
                using (avrasContext contexto = new avrasContext())
                {
                    var TipoProduto = contexto.TipoProduto.Where(p => p.Id == id).FirstOrDefault();
                    if (TipoProduto != null)
                    {
                        contexto.TipoProduto.Remove(TipoProduto);
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
