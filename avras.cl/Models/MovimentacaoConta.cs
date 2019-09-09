using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class MovimentacaoConta
    {
        internal int Id { get; set; }
        internal string Motivo { get; set; }
        internal DateTime Data { get; set; }
        internal decimal Valor { get; set; }
        internal int CargoId { get; set; }
        internal int ContaCorrenteId { get; set; }

        internal virtual Cargo Cargo { get; set; }
        internal virtual ContaCorrente ContaCorrente { get; set; }
    }
}
