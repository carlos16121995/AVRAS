using System;
using System.Collections.Generic;
using System.Text;
using avras.cl.DAL;

namespace avras.cl.Models
{
    internal partial class SociedadeTempo
    {
        public List<SociedadeTempo> BuscarSociedadeTempo(int id)
        {
            return new TempoSociedadeDAO().BuscarSociedadeTempo(id);
        }
        public int Gravar()
        { 
            int val = new TempoSociedadeDAO().Gravar(this);
            if(val == 90)
            {
                return new TempoSociedadeDAO().Change(this.PessoaId);
            }
            return val;
        }
        public int Alterar(int id)
        {
            return new TempoSociedadeDAO().Alterar(id);
        }
        public int Excluir(int id)
        {
            return new TempoSociedadeDAO().Excluir(id);
        }
    }
}
