using avras.cl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace avras.cl.DAL
{
    class TipoContaDAO
    {
        internal int Gravar(TipoConta tipoConta)
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    if (tipoConta.Id == 0)
                    {
                        contexto.TipoConta.Add(tipoConta);
                    }
                    else
                    {
                        contexto.TipoConta.Attach(tipoConta);

                    }
                    return contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        internal TipoConta BuscarTipoContaPorId(int id)
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    return contexto.TipoConta.Find(id);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        internal List<TipoConta> BuscarTipoConta()
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    return contexto.TipoConta.OrderBy(p => p.Nome).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        internal int Alterar(TipoConta tcAlterado)
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    var tcAtual = contexto.TipoConta.Where(p => p.Id == tcAlterado.Id).FirstOrDefault();
                    tcAtual.Nome = tcAlterado.Nome;
                    tcAtual.Descricao = tcAlterado.Descricao;
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
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    var tipoConta = contexto.TipoConta.Where(p => p.Id == id).FirstOrDefault();
                    if (tipoConta != null)
                    {
                        contexto.TipoConta.Remove(tipoConta);
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
