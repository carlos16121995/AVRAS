using avras.cl.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace avras.cl.DAL
{
    class PatrimonioDAO
    {
        internal int Gravar(Patrimonio patrimonio)
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    if (patrimonio.Id == 0)
                    {
                        contexto.Patrimonio.Add(patrimonio);
                    }
                    else
                    {
                        contexto.Patrimonio.Attach(patrimonio);

                    }
                    return contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        internal int Alterar(Patrimonio pAlterado)
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    var pAtual = contexto.Patrimonio.Where(p => p.Id == pAlterado.Id).Include("TipoPatrimonio").FirstOrDefault();
                    pAtual.Nome = pAlterado.Nome;
                    pAtual.Descicao = pAlterado.Descicao;
                    pAtual.Quantidade = pAlterado.Quantidade;
                    pAtual.ValorCompra = pAlterado.ValorCompra;
                    pAtual.ValorPerda = pAlterado.ValorPerda;
                    pAtual.Disponibilidade = pAlterado.Disponibilidade;
                    pAtual.Anotacao = pAlterado.Anotacao;
                    pAtual.DataAquisicao = pAlterado.DataAquisicao;
                    pAtual.DataPerda = pAlterado.DataPerda;
                    pAtual.TipoPatrimonioId = pAlterado.TipoPatrimonioId;


                    return contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        internal Patrimonio BuscarPatrimoniosPorId(int id)
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    return contexto.Patrimonio.Find(id);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        internal List<Patrimonio> BuscarPatrimoniosPorNome(string nome) 
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    nome = "%" + nome + "%";
                    return (from p in contexto.Patrimonio
                            where EF.Functions.Like(p.Nome, nome)
                            select p).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        internal List<Patrimonio> BuscarProdutos()
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    return contexto.Patrimonio.OrderBy(p => p.Nome).ToList();
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
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    var patrimonio = contexto.Patrimonio.Where(p => p.Id == id).FirstOrDefault();
                    if (patrimonio != null)
                    {
                        contexto.Patrimonio.Remove(patrimonio);
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
