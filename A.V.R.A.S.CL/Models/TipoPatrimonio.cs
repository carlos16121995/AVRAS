using System;
using System.Collections.Generic;

namespace A.V.R.A.S.CL.Models
{
    internal partial class TipoPatrimonio
    {
        public TipoPatrimonio()
        {
            Patrimonio = new HashSet<Patrimonio>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Patrimonio> Patrimonio { get; set; }
    }
}
