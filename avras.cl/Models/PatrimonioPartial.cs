using avras.cl.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace avras.cl.Models
{
    internal partial class Patrimonio
    {
        public int Gravar()
        {
            return new PatrimonioDAO().Gravar(this);
        }
        public int Alterar()
        {
            return new PatrimonioDAO().Alterar(this);
        }
        public List<Patrimonio> BuscarPatrimonios()
        {
            return new PatrimonioDAO().BuscarProdutos();
        }
        public List<Patrimonio> BuscarPatrimoniosPorNome(string nome)
        {
            return new PatrimonioDAO().BuscarPatrimoniosPorNome(nome);
        }
        public Patrimonio BuscarProdutosPorId(int id)
        {
            return new PatrimonioDAO().BuscarPatrimoniosPorId(id);
        }

        public int Excluir(int id)
        {
            return new PatrimonioDAO().Excluir(id);
        }
    }
}
