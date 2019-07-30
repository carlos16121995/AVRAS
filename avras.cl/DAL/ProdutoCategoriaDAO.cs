using System;
using System.Collections.Generic;
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
