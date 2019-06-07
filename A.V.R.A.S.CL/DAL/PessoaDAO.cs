using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A.V.R.A.S.CL.Models;
using Microsoft.EntityFrameworkCore;



namespace A.V.R.A.S.CL.DAL
{
    internal class PessoaDAO
    {
        internal int Gravar(Pessoa pessoa)
        {
            try
            {
                using (avras2019Context contexto = new avras2019Context())
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
        internal int Alterar(Pessoa pAlterado)
        {
            try
            {
                using (avras2019Context contexto = new avras2019Context())
                {
                    var pAtual = contexto.Pessoa.Where(p => p.Id == pAlterado.Id).Include("Endereco").FirstOrDefault();
                    pAtual.Nome = pAlterado.Nome;
                    pAtual.DataNascimento = pAlterado.DataNascimento;
                    pAtual.Email = pAlterado.Email;
                    pAtual.Telefone = pAlterado.Telefone;
                    if (pAlterado.Senha != null)
                        pAtual.Senha = pAlterado.Senha;
                    if (pAlterado.PendenciaId != null)
                        pAtual.PendenciaId = pAlterado.PendenciaId;
                    pAtual.Socio = pAlterado.Socio;
                    pAtual.Jogador = pAlterado.Jogador;
                    pAtual.Isento = pAlterado.Isento;
                    if(pAlterado.Observacoes != null)
                        pAtual.Observacoes = pAlterado.Observacoes;
                    pAtual.Endereco.Cep = pAlterado.Endereco.Cep;
                    pAtual.Endereco.Cidade = pAlterado.Endereco.Cidade;
                    pAtual.Endereco.Bairro = pAlterado.Endereco.Bairro;
                    pAtual.Endereco.Rua = pAlterado.Endereco.Rua;
                    pAtual.Endereco.Numero = pAlterado.Endereco.Numero;
                    pAtual.Endereco.Complemento = pAlterado.Endereco.Complemento;

                    
                    return contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        internal Pessoa BuscarPorCpf(string cpf)
        {
            try
            {
                using (avras2019Context contexto = new avras2019Context())
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

