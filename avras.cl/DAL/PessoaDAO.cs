using System;
using System.Collections.Generic;
using System.Text;
using avras.cl.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace avras.cl.DAL
{
    public class PessoaDAO
    {
        internal int Gravar(Pessoa pessoa)
        {
            try
            {
                using (avrasContext contexto = new avrasContext())
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
                using (avrasContext contexto = new avrasContext())
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
                    if (pAlterado.Observacoes != null)
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
                using (avrasContext contexto = new avrasContext())
                {
                    return (from p in contexto.Pessoa
                            where p.Cpf == cpf
                            select p).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        internal List<Pessoa> BuscarUsuarioPorNome(string nome)
        {
            try
            {
                using (avrasContext contexto = new avrasContext())
                {
                    nome = "%" + nome + "%";
                    return (from p in contexto.Pessoa
                            where EF.Functions.Like(p.Nome, nome)
                            select p).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        internal List<Pessoa> BuscarPessoa(int tipo)
        {
            try
            {
                using (avrasContext contexto = new avrasContext())
                {
                    if (tipo == 1)
                    {
                        return contexto.Pessoa.OrderBy(p => p.Nome).ToList();
                    }
                    if (tipo == 2)
                    {
                        byte t = 1;
                        return contexto.Pessoa.Include("Endereco").Where(p => p.Socio == t).ToList();
                    }
                    else
                    {
                        byte t = 1;
                        return contexto.Pessoa.Include("Endereco").Where(p => p.Jogador == t).ToList();
                    }
                   
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
                using (avrasContext contexto = new avrasContext())
                {
                    var pessoa = contexto.Pessoa.Include("Endereco").Where(p => p.Id == id).FirstOrDefault();
                    if (pessoa != null)
                    {
                        var endereco = pessoa.Endereco;
                        contexto.Endereco.Remove(endereco);
                        contexto.Pessoa.Remove(pessoa);
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
        public int TrocarSenha(string email, string senha, string senhaNova)
        {
            try
            {
                using (avrasContext contexto = new avrasContext())
                {
                    Pessoa pes = (from p in contexto.Pessoa
                            where p.Email == email && p.Senha == senha
                            select p).FirstOrDefault();
                    pes.Senha = senhaNova;
                    contexto.Attach(pes);
                    return contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return 0;
            }

            

        }
        internal Pessoa Autenticar(string email, string senha)
        {
            try
            {
                using (avrasContext contexto = new avrasContext())
                {
                    return (from p in contexto.Pessoa
                            where p.Email == email && p.Senha == senha
                            select p).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        internal Pessoa BuscarPessoaPorId(int id)
        {
            try
            {
                using (avrasContext contexto = new avrasContext())
                {
                    return contexto.Pessoa.Find(id);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
