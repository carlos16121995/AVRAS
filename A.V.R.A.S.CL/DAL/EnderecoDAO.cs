using System;
using System.Collections.Generic;
using System.Text;
using A.V.R.A.S.CL.Models;
using System.Linq;


namespace A.V.R.A.S.CL.DAL
{
    internal class EnderecoDAO
    {
        internal Endereco BuscarEnderecoPorId(int id)
        {
            try
            {
                using (avras2019Context contexto = new avras2019Context())
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