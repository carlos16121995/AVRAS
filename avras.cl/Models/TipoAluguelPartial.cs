using avras.cl.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace avras.cl.Models
{
    internal partial class TipoAluguel
    {
        public int Gravar()
        {
            return new TipoAluguelDAO().Gravar(this);
        }
        public int Alterar()
        {
            return new TipoAluguelDAO().Alterar(this);
        }
        public List<TipoAluguel> BuscarTipoAluguel()
        {
            return new TipoAluguelDAO().BuscarTipoAluguel();
        }
        public TipoAluguel BuscarTipoAluguelPorId(int id)
        {
            return new TipoAluguelDAO().BuscarTipoAluguelPorId(id);
        }
        public int Excluir(int id)
        {
            return new TipoAluguelDAO().Excluir(id);
        }
    }
}
