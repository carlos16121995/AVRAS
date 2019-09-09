using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class TipoAluguel
    {
        internal TipoAluguel()
        {
            Aluguel = new HashSet<Aluguel>();
        }

        internal int Id { get; set; }
        internal string Nome { get; set; }
        internal decimal Valor { get; set; }

        internal virtual ICollection<Aluguel> Aluguel { get; set; }
    }
}
