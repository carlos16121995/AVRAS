using avras.cl.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace avras.cl.Models
{
    internal partial class ContaCorrente
    {
        public int Gravar()
        {
            return new ContaCorrenteDAO().Gravar(this);
        }
        public int Alterar()
        {
            return new ContaCorrenteDAO().Alterar(this);
        }
        public List<ContaCorrente> BuscarContaCorrente()
        {
            return new ContaCorrenteDAO().BuscarContaCorrente();
        }
        public ContaCorrente BuscarTipoContaPorId(int id)
        {
            return new ContaCorrenteDAO().BuscarContaCorrentePorId(id);
        }
        public int Excluir(int id)
        {
            return new ContaCorrenteDAO().Excluir(id);
        }
    }
}
