using avras.cl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace avras.cl.DAL
{
    class TipoAluguelDAO
    {
        internal int Gravar(TipoAluguel tipoAluguel)
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    if (tipoAluguel.Id == 0)
                    {
                        contexto.TipoAluguel.Add(tipoAluguel);
                    }
                    else
                    {
                        contexto.TipoAluguel.Attach(tipoAluguel);

                    }
                    return contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        internal TipoAluguel BuscarTipoAluguelPorId(int id)
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    return contexto.TipoAluguel.Find(id);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        internal List<TipoAluguel> BuscarTipoAluguel()
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    return contexto.TipoAluguel.OrderBy(p => p.Nome).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        internal int Alterar(TipoAluguel taAlterado)
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    var tpAtual = contexto.TipoAluguel.Where(p => p.Id == taAlterado.Id).FirstOrDefault();
                    tpAtual.Nome = taAlterado.Nome;
                    tpAtual.Valor = taAlterado.Valor;
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
                    var tipoAluguel = contexto.TipoAluguel.Where(p => p.Id == id).FirstOrDefault();
                    if (tipoAluguel != null)
                    {
                        contexto.TipoAluguel.Remove(tipoAluguel);
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
