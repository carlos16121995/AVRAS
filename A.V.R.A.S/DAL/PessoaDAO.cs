using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A.V.R.A.S.Models;
using Microsoft.EntityFrameworkCore;

namespace A.V.R.A.S.DAL
{
    public class PessoaDAO
    {
        public int Gravar(Pessoa pessoa)
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    if (pessoa.Id == 0)
                    {
                        contexto.Pessoa.Add(pessoa);
                    }
                    else
                    {
                        contexto.Pessoa.Attach(pessoa);
                        
                    }
                    return contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public int Alterar(Pessoa pAlterado)
        {
            try
            {
                using(avrastesteContext contexto = new avrastesteContext())
                {
                    var pAtual = contexto.Pessoa.Where(p=> p.Id == pAlterado.Id).FirstOrDefault();
                    pAtual.Nome = pAlterado.Nome;
                    pAtual.Email = pAlterado.Email;
                    pAtual.Telefone = pAlterado.Telefone;

                    return -0; 
                }
            }
            catch(Exception ex)
            {
                    return -1;
            }
        }
        public Pessoa BuscarPorCpf(string cpf)
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    return (from p in contexto.Pessoa.Include("Endereco")
                            where p.Cpf == cpf
                            select p).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
