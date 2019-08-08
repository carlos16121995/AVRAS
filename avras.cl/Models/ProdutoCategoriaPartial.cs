using System;
using System.Collections.Generic;
using System.Text;
using avras.cl.DAL;

namespace avras.cl.Models
{
    internal partial class ProdutoCategoria
    {
        public List<ProdutoCategoria> BuscarCategorias()
        {
            return new ProdutoCategoriaDAO().BuscarCategorias();
        }
        public ProdutoCategoria BuscarCategoriaPorId(int id)
        {
            return new ProdutoCategoriaDAO().BuscarCategoriaPorId(id);
        }
    }
}
