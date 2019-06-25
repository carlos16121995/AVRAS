using avras.cl.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace avras.cl.Models
{
    internal partial class Endereco
    {
        public Endereco BuscarEnderecoPorId(int id)
        {
            return new EnderecoDAO().BuscarEnderecoPorId(id);
        }
    }
}
