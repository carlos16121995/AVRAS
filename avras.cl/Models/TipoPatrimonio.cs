using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class TipoPatrimonio
    {
        internal TipoPatrimonio()
        {
            Patrimonio = new HashSet<Patrimonio>();
        }

        internal int Id { get; set; }
        internal string Nome { get; set; }
        internal string Descricao { get; set; }

        internal virtual ICollection<Patrimonio> Patrimonio { get; set; }
    }
}
