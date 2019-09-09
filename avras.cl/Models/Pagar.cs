using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class Pagar
    {
        internal int ContaId { get; set; }
        internal decimal? ValorPago { get; set; }
        internal DateTime? DataPagamento { get; set; }
        internal int Parcelas { get; set; }

        internal virtual Conta Conta { get; set; }
    }
}
