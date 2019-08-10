using avras.cl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace avras.cl.DAL
{
    class ContaCorrenteDAO
    {
        internal int Gravar(ContaCorrente contaCorrente)
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    if (contaCorrente.Id == 0)
                    {
                        contexto.ContaCorrente.Add(contaCorrente);
                    }
                    else
                    {
                        contexto.ContaCorrente.Attach(contaCorrente);

                    }
                    return contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        internal ContaCorrente BuscarContaCorrentePorId(int id)
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    return contexto.ContaCorrente.Find(id);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        internal List<ContaCorrente> BuscarContaCorrente()
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    return contexto.ContaCorrente.OrderBy(p => p.Valor).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        internal int Alterar(ContaCorrente ccAlterado)
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    var ccAtual = contexto.ContaCorrente.Where(p => p.Id == ccAlterado.Id).FirstOrDefault();
                    ccAtual.Valor = ccAlterado.Valor;
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
                    var contaCorrente = contexto.ContaCorrente.Where(p => p.Id == id).FirstOrDefault();
                    if (contaCorrente != null)
                    {
                        contexto.ContaCorrente.Remove(contaCorrente);
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
