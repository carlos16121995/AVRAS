using System;
using System.Collections.Generic;
using System.Text;
using A.V.R.A.S.CL.ViewModels;
using A.V.R.A.S.CL.Models;

namespace A.V.R.A.S.CL.Controllers
{
    public class PessoaController
    {
        public int Gravar(PessoaViewModel p)
        {
            Endereco endereco = new Endereco()
            {
                Cep = p.Endereco.Cep,
                Cidade = p.Endereco.Cidade,
                Bairro = p.Endereco.Bairro,
                Rua = p.Endereco.Rua,
                Numero = p.Endereco.Numero,
                Complemento = p.Endereco.Complemento,
            };
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
            return pessoa.Gravar();
        }
        public int Alterar(PessoaViewModel p)
        {
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
        public PessoaViewModel BuscarPorCPF(string cpf)
        {
            var p = new Pessoa().BuscarPorCpf(cpf);
            if (p != null)
            {
                EnderecoViewModel endereco = new EnderecoViewModel()
                {
                    PessoaId = p.Id,
                    Cep = p.Endereco.Cep,
                    Cidade = p.Endereco.Cidade,
                    Bairro = p.Endereco.Bairro,
                    Rua = p.Endereco.Rua,
                    Numero = p.Endereco.Numero,
                    Complemento = p.Endereco.Complemento,
                };
                return new PessoaViewModel()
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
                    PendenciaId = p.PendenciaId,
                };
            }
            return null;

        }
    }
}
