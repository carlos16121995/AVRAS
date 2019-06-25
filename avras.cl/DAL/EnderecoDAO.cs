using System;
using System.Collections.Generic;
using System.Text;
using avras.cl.Models;
using System.Linq;

namespace avras.cl.DAL
{
    internal class EnderecoDAO
    {
        internal Endereco BuscarEnderecoPorId(int id)
        {
            try
            {
                using (avrastesteContext contexto = new avrastesteContext())
                {
                    return (from e in contexto.Endereco
                            where e.PessoaId == id
                            select e).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
