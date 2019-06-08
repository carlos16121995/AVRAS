using System;
using System.Collections.Generic;
using System.Text;
using A.V.R.A.S.CL.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace A.V.R.A.S.CL.DAL
{
    class PatrocinadoresDAO
    {
        internal int Gravar(Patrocinadores patrocinadores)
        {
            try
            {
                using (avras2019Context contexto = new avras2019Context())
                {
                    if (patrocinadores.Id == 0)
                    {
                        contexto.Patrocinadores.Add(patrocinadores);
                    }
                    else
                    {
                        contexto.Patrocinadores.Attach(patrocinadores);

                    }
                    return contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        internal int Alterar(Patrocinadores pAlterado)
        {
            try
            {
                using (avras2019Context contexto = new avras2019Context())
                {
                    var pAtual = contexto.Patrocinadores.Where(p => p.Id == pAlterado.Id).FirstOrDefault();
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
        }
        internal List<Patrocinadores> BuscarPatrocinadoresPorNome(string nome)
        {
            try
            {
                using (avras2019Context contexto = new avras2019Context())
                {
                    nome = "%" + nome + "%";
                    return (from p in contexto.Patrocinadores
                            where EF.Functions.Like(p.Nome, nome)
                            select p).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        internal List<Patrocinadores> BuscarPatrocinadores()
        {
            try
            {
                using (avras2019Context contexto = new avras2019Context())
                {
                    return contexto.Patrocinadores.OrderBy(p => p.Nome).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        internal int Excluir(int id)
        {
            try
            {
                using (avras2019Context contexto = new avras2019Context())
                {
                    var patrocinadores = contexto.Patrocinadores.Where(p => p.Id == id).FirstOrDefault();
                    if (patrocinadores != null)
                    {
                        contexto.Patrocinadores.Remove(patrocinadores);
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
