using avras.cl.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace avras.cl.Models
{
    internal partial class Caixa
    {
        public int Gravar()
        {
            return new CaixaDAO().Gravar(this);
        }
        public int Alterar()
        {
            return new CaixaDAO().Alterar(this);
        }
        public List<Caixa> BuscarCaixa()
        {
            return new CaixaDAO().BuscarCaixa();
        }
        public Caixa BuscarCaixaPorId(int id)
        {
            return new CaixaDAO().BuscarCaixaPorId(id);
        }
        public int Excluir(int id)
        {
            return new CaixaDAO().Excluir(id);
        }
    }
}
