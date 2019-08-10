using System;
using System.Collections.Generic;
using System.Text;
using avras.cl.DAL;

namespace avras.cl.Models
{
    internal partial class TipoPatrimonio
    {
        public int Gravar()
        {
            return new TipoPatrimonioDAO().Gravar(this);
        }
        public int Alterar()
        {
            return new TipoPatrimonioDAO().Alterar(this);
        }
        public List<TipoPatrimonio> BuscarTipoPatrimonio()
        {
            return new TipoPatrimonioDAO().BuscarTipoPatrimonio();
        }
        public TipoPatrimonio BuscarTipoPatrimonioPorId(int id)
        {
            return new TipoPatrimonioDAO().BuscarTipoPatrimonioPorId(id);
        }
        public int Excluir(int id)
        {
            return new TipoPatrimonioDAO().Excluir(id);
        }
    }
}
