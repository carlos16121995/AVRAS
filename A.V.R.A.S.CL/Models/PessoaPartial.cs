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
    }
}
