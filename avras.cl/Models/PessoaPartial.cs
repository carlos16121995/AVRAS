using avras.cl.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace avras.cl.Models
{
    internal partial class Pessoa
    {
        public int Gravar()
        {
            return new PessoaDAO().Gravar(this);
        }
        public int Alterar()
        {
            return new PessoaDAO().Alterar(this);
        }
        public Pessoa BuscarPorCpf(string cpf)
        {
            return new PessoaDAO().BuscarPorCpf(cpf);
        }
        public List<Pessoa> BuscarPessoa(int tipo)
        {
            return new PessoaDAO().BuscarPessoa(tipo);
        }
        public List<Pessoa> BuscarUsuarioPorNome(string nome)
        {
            return new PessoaDAO().BuscarUsuarioPorNome(nome);
        }
        public int Excluir(int id)
        {
            return new PessoaDAO().Excluir(id);
        }
        public Pessoa BuscarPessoaPorId(int id)
        {
            return new PessoaDAO().BuscarPessoaPorId(id);
        }
        public Pessoa Autenticar(string email, string senha)
        {
            return new PessoaDAO().Autenticar(email, senha);
        }
    }
}
