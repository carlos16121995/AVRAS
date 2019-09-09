using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class TipoCargo
    {
        internal TipoCargo()
        {
            Cargo = new HashSet<Cargo>();
        }

        internal int Id { get; set; }
        internal string Nome { get; set; }
        internal string Descricao { get; set; }
        internal int Permissao { get; set; }

        internal virtual ICollection<Cargo> Cargo { get; set; }
    }
}
