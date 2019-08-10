using System;
using System.Collections.Generic;
using System.Text;
using avras.cl.DAL;

namespace avras.cl.Models
{
    internal partial class ProdutoCategoria
    {
        public int Gravar()
        {
            return new ProdutoCategoriaDAO().Gravar(this);
        }
        public int Alterar()
        {
            return new ProdutoCategoriaDAO().Alterar(this);
        }
        public List<ProdutoCategoria> BuscarProdutoCategoria()
        {
            return new ProdutoCategoriaDAO().BuscarCategorias();
        }
        public ProdutoCategoria BuscarProdutoCategoriaPorId(int id)
        {
            return new ProdutoCategoriaDAO().BuscarCategoriaPorId(id);
        }
        public int Excluir(int id)
        {
            return new TipoContaDAO().Excluir(id);
        }
    }
}
