using avras.cl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using avras.cl.DAL;
using avras.cl.ViewModels;

namespace avras.cl.Controllers
{
    public class PessoaController
    {
        /// <summary>
        /// Recebe um Objeto do tipo PessoaViewModel para gravação
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public int Gravar(PessoaViewModel p)
        {
            int result;
            new TempoSociedadeDAO().Check(p.Id, p.Socio);
            Endereco endereco = new Endereco()
            {
                Cep = p.Endereco.Cep,
                Cidade = p.Endereco.Cidade,
                Bairro = p.Endereco.Bairro,
                Rua = p.Endereco.Rua,
                Numero = p.Endereco.Numero,
                Complemento = p.Endereco.Complemento,
            };
            SociedadeTempo sociedadeTempo = new SociedadeTempo();
           

           
            Pessoa pessoa = new Pessoa()
            {
                Cpf = p.Cpf,
                Nome = p.Nome,
                Email = p.Email,
                DataNascimento = p.DataNascimento,
                Telefone = p.Telefone,
                Endereco = endereco,
                Socio = p.Socio,
                Jogador = p.Jogador,
                Isento = p.Isento,
            };
            if (p.Pendencia != null)
            {
                pessoa.PendenciaId = p.PendenciaId;
            }
            if (p.Senha != null)
            {
                pessoa.Senha = p.Senha;
            }
            if (p.Id != 0)
            {
                pessoa.Id = p.Id;
                result = pessoa.Alterar();
            }
            else
            {
                result = pessoa.Gravar();
            }

            return result;
        }
        /// <summary>
        /// Recebe um Objeto do TipoViewModel para alteração
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int Alterar(PessoaViewModel p)
        {
            new TempoSociedadeDAO().Check(p.Id, p.Socio);
            Endereco endereco = new Endereco()
            {
                PessoaId = p.Id,
                Cep = p.Endereco.Cep,
                Cidade = p.Endereco.Cidade,
                Bairro = p.Endereco.Bairro,
                Rua = p.Endereco.Rua,
                Numero = p.Endereco.Numero,
                Complemento = p.Endereco.Complemento,
            };
            Pessoa pessoa = new Pessoa()
            {
                Id = p.Id,
                Cpf = p.Cpf,
                Nome = p.Nome,
                Email = p.Email,
                DataNascimento = p.DataNascimento,
                Telefone = p.Telefone,
                Endereco = endereco,
                Socio = p.Socio,
                Jogador = p.Jogador,
                Isento = p.Isento,
            };
            if (p.Pendencia != null)
            {
                pessoa.PendenciaId = p.PendenciaId;
            }
            if (p.Senha != null)
            {
                pessoa.Senha = p.Senha;
            }
            return pessoa.Alterar();
        }
        /// <summary>
        /// Busca uma pessoa por Cpf, caso o booleano for true ele retorna também o endereço
        /// </summary>
        /// <param name="cpf"></param>
        /// <param name="includeEndereco"></param>
        /// <returns></returns>
        public PessoaViewModel BuscarPorCPF(string cpf, bool includeEndereco = false)
        {
            var p = new Pessoa().BuscarPorCpf(cpf);
            if (p != null)
            {
                return new PessoaViewModel()
                {
                    Id = p.Id,
                    Cpf = p.Cpf,
                    Nome = p.Nome,
                    Email = p.Email,
                    DataNascimento = p.DataNascimento,
                    Telefone = p.Telefone,
                    Endereco = (includeEndereco == true ? BuscarEnderecoPorId(p.Id) : null),
                    Socio = p.Socio,
                    Jogador = p.Jogador,
                    Isento = p.Isento,
                    Observacoes = p.Observacoes,
                    PendenciaId = p.PendenciaId,
                };
            }
            return null;

        }
        public PessoaViewModel BuscarPessoaPorId(int id, bool includeEndereco = false)
        {
            var p = new Pessoa().BuscarPessoaPorId(id);
            if (p != null)
            {
                return new PessoaViewModel()
                {
                    Id = p.Id,
                    Cpf = p.Cpf,
                    Nome = p.Nome,
                    Email = p.Email,
                    DataNascimento = p.DataNascimento,
                    Telefone = p.Telefone,
                    Endereco = (includeEndereco == true ? BuscarEnderecoPorId(p.Id) : null),
                    Socio = p.Socio,
                    Jogador = p.Jogador,
                    Isento = p.Isento,
                    Observacoes = p.Observacoes,
                    PendenciaId = p.PendenciaId,
                };
            }
            return null;

        }
        public List<PessoaViewModel> BuscarUsuarioPorNome(string nome, bool includeEndereco = false)
        {
            var pessoas = new Pessoa().BuscarUsuarioPorNome(nome);
            if (pessoas != null && pessoas.Count > 0)

                return (from pessoa in pessoas
                        select new PessoaViewModel()
                        {
                            Id = pessoa.Id,
                            Cpf = pessoa.Cpf,
                            Nome = pessoa.Nome,
                            Email = pessoa.Email,
                            DataNascimento = pessoa.DataNascimento,
                            Telefone = pessoa.Telefone,
                            Endereco = (includeEndereco == true ? BuscarEnderecoPorId(pessoa.Id) : null),
                            Socio = pessoa.Socio,
                            Jogador = pessoa.Jogador,
                            Isento = pessoa.Isento,
                            PendenciaId = pessoa.PendenciaId,
                        }).ToList();
            else
                return null;

        }
        public int Excluir(int id)
        {
            return new Pessoa().Excluir(id);
        }
        /// <summary>
        /// Busca todos os usuarios cadastrados, caso o boolean seja true retorna seus endereços
        /// </summary>
        /// <param name="includeEndereco">boolean</param>
        /// <returns></returns>
        public List<PessoaViewModel> BuscarUsuarios(int tipo, bool includeEndereco = false)
        {
            var pessoas = new Pessoa().BuscarPessoa(tipo);
            if (pessoas != null && pessoas.Count > 0)

                return (from pessoa in pessoas
                        select new PessoaViewModel()
                        {
                            Id = pessoa.Id,
                            Cpf = pessoa.Cpf,
                            Nome = pessoa.Nome,
                            Email = pessoa.Email,
                            DataNascimento = pessoa.DataNascimento,
                            Telefone = pessoa.Telefone,
                            Endereco = (includeEndereco == true ? BuscarEnderecoPorId(pessoa.Id) : null),
                            Socio = pessoa.Socio,
                            Jogador = pessoa.Jogador,
                            Isento = pessoa.Isento,
                            PendenciaId = pessoa.PendenciaId,
                        }).ToList();
            else
                return null;
        }
        /// <summary>
        /// Retorna O endereço de um usuário, caso o boolean seja true ele retorna também o usuário
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includePessoa"></param>
        /// <returns></returns>
        public EnderecoViewModel BuscarEnderecoPorId(int id, bool includePessoa = false)
        {
            var endereco = new Endereco().BuscarEnderecoPorId(id);
            if (endereco != null)
            {
                return new EnderecoViewModel
                {
                    PessoaId = endereco.PessoaId,
                    Cep = endereco.Cep,
                    Cidade = endereco.Cidade,
                    Bairro = endereco.Bairro,
                    Rua = endereco.Rua,
                    Numero = endereco.Numero,
                    Complemento = endereco.Complemento,
                };
            }
            return null;
        }
        public PessoaViewModel Autenticar(string email, string senha)
        {
            var p = new Pessoa().Autenticar(email, senha);
            if (p != null)
            {
                return new PessoaViewModel()
                {
                    Id = p.Id,
                    Cpf = p.Cpf,
                    Nome = p.Nome,
                    Email = p.Email,
                    DataNascimento = p.DataNascimento,
                    Telefone = p.Telefone,
                    Endereco = BuscarEnderecoPorId(p.Id),
                    Socio = p.Socio,
                    Jogador = p.Jogador,
                    Isento = p.Isento,
                    PendenciaId = p.PendenciaId,
                };
            }
            return null;
        }
        // SOCIEDADE TEMPO

        public int Gravar(SociedadeTempoViewModel st)
        {
            SociedadeTempo ts = new SociedadeTempo()
            {
                DataInicio = st.DataInicio,
                DataFim = st.DataFim,
                PessoaId = st.PessoaId,
            };

            return ts.Gravar();
        }
        public List<SociedadeTempoViewModel> BuscarSociedadeTempo(int id)
        {
            List<SociedadeTempo> ts = new SociedadeTempo().BuscarSociedadeTempo(id);
            return (from SociedadeTempo in ts
                    select new SociedadeTempoViewModel()
                    {
                        Id = SociedadeTempo.Id,
                        DataInicio = SociedadeTempo.DataInicio,
                        DataFim = SociedadeTempo.DataFim,
                        PessoaId = SociedadeTempo.PessoaId,
                        
                    }).ToList();
        }
        public int ExcluirSociedadeTempo(int id)
        {
            return new SociedadeTempo().Excluir(id);
        }
        public int Alterar(int id)
        {

            return new SociedadeTempo().Alterar(id);
        }
    }
}
