using avras.cl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace avras.cl.DAL
{
    class CaixaDAO
    {
        internal int Gravar(Caixa caixa)
        {
            try
            {
                using (avrasContext contexto = new avrasContext())
                {
                    if (caixa.Id == 0)
                    {
                        contexto.Caixa.Add(caixa);
                    }
                    else
                    {
                        contexto.Caixa.Attach(caixa);

                    }
                    return contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        internal Caixa BuscarCaixaPorId(int id)
        {
            try
            {
                using (avrasContext contexto = new avrasContext())
                {
                    return contexto.Caixa.Find(id);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        internal List<Caixa> BuscarCaixa()
        {
            try
            {
                using (avrasContext contexto = new avrasContext())
                {
                    return contexto.Caixa.OrderBy(p => p.Valor).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        internal int Alterar(Caixa cAlterado)
        {
            try
            {
                using (avrasContext contexto = new avrasContext())
                {
                    var cAtual = contexto.Caixa.Where(p => p.Id == cAlterado.Id).FirstOrDefault();
                    cAtual.Valor = cAlterado.Valor;
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
                    var caixa = contexto.Caixa.Where(p => p.Id == id).FirstOrDefault();
                    if (caixa != null)
                    {
                        contexto.Caixa.Remove(caixa);
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
