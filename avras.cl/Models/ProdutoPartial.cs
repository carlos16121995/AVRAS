using System;
using System.Collections.Generic;
using System.Text;
using avras.cl.DAL;

namespace avras.cl.Models
{
    internal partial class Produto
    {
        public int Gravar()
        {
            return new ProdutoDAO().Gravar(this);
        }
        public int Alterar()
        {
            return new ProdutoDAO().Alterar(this);
        }
        public List<Produto> BuscarProdutos()
        {
            return new ProdutoDAO().BuscarProdutos();
        }
        public List<Produto> BuscarProdutosPorNome(string nome)
        {
            return new ProdutoDAO().BuscarProdutosPorNome(nome);
        }
        public Produto BuscarProdutosPorId(int id)
        {
            return new ProdutoDAO().BuscarProdutosPorId(id);
        }
        public int Excluir(int id)
        {
            return new ProdutoDAO().Excluir(id);
        }
    }  
}
