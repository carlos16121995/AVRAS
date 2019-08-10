using avras.cl.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace avras.cl.Models
{
    internal partial class TipoConta
    {
        public int Gravar()
        {
            return new TipoContaDAO().Gravar(this);
        }
        public int Alterar()
        {
            return new TipoContaDAO().Alterar(this);
        }
        public List<TipoConta> BuscarTipoConta()
        {
            return new TipoContaDAO().BuscarTipoConta();
        }
        public TipoConta BuscarTipoContaPorId(int id)
        {
            return new TipoContaDAO().BuscarTipoContaPorId(id);
        }
        public int Excluir(int id)
        {
            return new TipoContaDAO().Excluir(id);
        }
    }
}
