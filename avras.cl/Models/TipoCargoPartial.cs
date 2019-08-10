using avras.cl.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace avras.cl.Models
{
    internal partial class TipoCargo
    {
        public int Gravar()
        {
            return new TipoCargoDAO().Gravar(this);
        }
        public int Alterar()
        {
            return new TipoCargoDAO().Alterar(this);
        }
        public List<TipoCargo> BuscarTipoCargo()
        {
            return new TipoCargoDAO().BuscarTipoCargo();
        }
        public TipoCargo BuscarTipoCargoPorId(int id)
        {
            return new TipoCargoDAO().BuscarTipoCargoPorId(id);
        }
        public int Excluir(int id)
        {
            return new TipoCargoDAO().Excluir(id);
        }
    }
}
