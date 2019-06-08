using System;
using System.Collections.Generic;
using System.Text;
using A.V.R.A.S.CL.DAL;

namespace A.V.R.A.S.CL.Models
{
    internal partial class Endereco
    {
        public Endereco BuscarEnderecoPorId(int id)
        {
            return new EnderecoDAO().BuscarEnderecoPorId(id);
        }
    }
}
