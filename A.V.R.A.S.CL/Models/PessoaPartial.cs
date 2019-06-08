using System;
using System.Collections.Generic;
using System.Text;
using A.V.R.A.S.CL.DAL;

namespace A.V.R.A.S.CL.Models
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
        public List<Pessoa> BuscarPessoa()
        {
            return new PessoaDAO().BuscarPessoa();
        }
        public List<Pessoa> BuscarUsuarioPorNome(string nome)
        {
            return new PessoaDAO().BuscarUsuarioPorNome(nome);
        }
        public int Excluir(int id)
        {
            return new PessoaDAO().Excluir(id);
        }
        public Pessoa Autenticar(string email, string senha)
        {
            return new PessoaDAO().Autenticar(email, senha);
        }
        
    }
    
}
