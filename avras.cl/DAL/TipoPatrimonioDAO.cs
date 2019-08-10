using avras.cl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace avras.cl.DAL
{
    class TipoPatrimonioDAO

    {
        internal int Gravar(TipoPatrimonio tipoPatrimonio)
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    if (tipoPatrimonio.Id == 0)
                    {
                        contexto.TipoPatrimonio.Add(tipoPatrimonio);
                    }
                    else
                    {
                        contexto.TipoPatrimonio.Attach(tipoPatrimonio);

                    }
                    return contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        internal TipoPatrimonio BuscarTipoPatrimonioPorId(int id)
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    return contexto.TipoPatrimonio.Find(id);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        internal List<TipoPatrimonio> BuscarTipoPatrimonio()
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    return contexto.TipoPatrimonio.OrderBy(p => p.Nome).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        internal int Alterar(TipoPatrimonio tpAlterado)
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    var tpAtual = contexto.TipoPatrimonio.Where(p => p.Id == tpAlterado.Id).FirstOrDefault();
                    tpAtual.Nome = tpAlterado.Nome;
                    tpAtual.Descricao = tpAlterado.Descricao;
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
                    var tipoPatrimonio = contexto.TipoPatrimonio.Where(p => p.Id == id).FirstOrDefault();
                    if (tipoPatrimonio != null)
                    {
                        contexto.TipoPatrimonio.Remove(tipoPatrimonio);
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
