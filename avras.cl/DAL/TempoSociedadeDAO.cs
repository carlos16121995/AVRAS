using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using avras.cl.Models;
using Microsoft.EntityFrameworkCore;

namespace avras.cl.DAL
{
    internal class TempoSociedadeDAO
    {
        internal List<SociedadeTempo> BuscarSociedadeTempo(int id)
        {
            try
            {
                using (avrasContext contexto = new avrasContext())
                {
                   
                        return contexto.SociedadeTempo.Include("Pessoa").Where(p => p.PessoaId == id).ToList();
                  
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        internal int Change(int id)
        {
            try
            {
                using (avrasContext contexto = new avrasContext())
                {
                    Pessoa pes = contexto.Pessoa.Find(id);
                    pes.Socio = 1;
                    contexto.Pessoa.Attach(pes);
                    return contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        internal int Gravar(SociedadeTempo ts)
        {
              try
            {
                using (avrasContext contexto = new avrasContext())
                {
                    int ret = 0;
                    SociedadeTempo Verifica = contexto.SociedadeTempo.Where(p => p.PessoaId == ts.PessoaId).Where(p => p.DataFim == null).FirstOrDefault();
                    if (Verifica == null)
                    {
                        contexto.SociedadeTempo.Add(ts);

                        contexto.SaveChanges();
                        return 90;
                    }
                    else if (Verifica != null && ts.DataFim != null)
                    {
                        contexto.SociedadeTempo.Add(ts);
                        return contexto.SaveChanges();
                    }
                    else return -99;


                    
                     

                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        internal void Check(int id, int socio)
        {
            try
            {
                using (avrasContext contexto = new avrasContext())
                {
                    SociedadeTempo verifica = contexto.SociedadeTempo.Where(p => p.PessoaId == id).Where(p => p.DataFim == null).FirstOrDefault();
                    if (verifica == null && socio == 1)
                    {
                        verifica = new SociedadeTempo();
                        verifica.DataInicio = DateTime.Now;
                        verifica.PessoaId = id;
                        contexto.SociedadeTempo.Add(verifica);
                    }
                    if(verifica != null && socio == 0)
                    {
                        verifica.DataFim = DateTime.Now;
                        contexto.SociedadeTempo.Attach(verifica);
                    }
                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        internal int Alterar(int id)
        {
            try
            {
                using (avrasContext contexto = new avrasContext())
                {
                    var tsAtual = contexto.SociedadeTempo.Where(p => p.Id == id).FirstOrDefault();
                  
                    tsAtual.DataFim = DateTime.Now;
                    Pessoa pes = contexto.Pessoa.Where(p => p.Id == tsAtual.PessoaId).FirstOrDefault();
                    pes.Socio = 0;
                    contexto.Pessoa.Attach(pes);
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
                    var ts = contexto.SociedadeTempo.Where(p => p.Id == id).Where(p => p.DataFim == null).FirstOrDefault();
                    if (ts != null)
                    {
                        contexto.SociedadeTempo.Remove(ts);
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
