using System;
using System.Collections.Generic;
using System.Text;
using avras.cl.DAL;

namespace avras.cl.Models
{
    internal partial class TipoProduto
    {
        public int Gravar()
        {
            return new TipoProdutoDAO().Gravar(this);
        }
        public int Alterar()
        {
            return new TipoProdutoDAO().Alterar(this);
        }
        public List<TipoProduto> BuscarTipoProduto()
        {
            return new TipoProdutoDAO().BuscarCategorias();
        }
        public TipoProduto BuscarTipoProdutoPorId(int id)
        {
            return new TipoProdutoDAO().BuscarCategoriaPorId(id);
        }
        public int Excluir(int id)
        {
            return new TipoProdutoDAO().Excluir(id);
        }
    }
}
