using avras.cl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace avras.cl.DAL
{
    class TipoCargoDAO
    {
        internal int Gravar(TipoCargo tipoCargo)
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    if (tipoCargo.Id == 0)
                    {
                        contexto.TipoCargo.Add(tipoCargo);
                    }
                    else
                    {
                        contexto.TipoCargo.Attach(tipoCargo);

                    }
                    return contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        internal TipoCargo BuscarTipoCargoPorId(int id)
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    return contexto.TipoCargo.Find(id);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        internal List<TipoCargo> BuscarTipoCargo()
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    return contexto.TipoCargo.OrderBy(p => p.Nome).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        internal int Alterar(TipoCargo tcAlterado)
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    var tcAtual = contexto.TipoCargo.Where(p => p.Id == tcAlterado.Id).FirstOrDefault();
                    tcAtual.Nome = tcAlterado.Nome;
                    tcAtual.Descricao = tcAlterado.Descricao;
                    tcAtual.Permissao = tcAlterado.Permissao;
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
                    var tipoCargo = contexto.TipoCargo.Where(p => p.Id == id).FirstOrDefault();
                    if (tipoCargo != null)
                    {
                        contexto.TipoCargo.Remove(tipoCargo);
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
