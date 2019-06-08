using A.V.R.A.S.CL.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace A.V.R.A.S.CL.Models
{
    internal partial class Patrocinadores
    {
        public int Gravar()
        {
            return new PatrocinadoresDAO().Gravar(this);
        }
        public int Alterar()
        {
            return new PatrocinadoresDAO().Alterar(this);
        }
        public List<Patrocinadores> BuscarPatrocinadores()
        {
            return new PatrocinadoresDAO().BuscarPatrocinadores();
        }
        public List<Patrocinadores> BuscarPatrocinadoresPorNome(string nome)
        {
            return new PatrocinadoresDAO().BuscarPatrocinadoresPorNome(nome);
        }
        public int Excluir(int id)
        {
            return new PatrocinadoresDAO().Excluir(id);
        }
    }
}
