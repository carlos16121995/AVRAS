using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class MovimentacaoCaixa
    {
        internal int Id { get; set; }
        internal string Motivo { get; set; }
        internal DateTime Data { get; set; }
        internal decimal Valor { get; set; }
        internal int CargoId { get; set; }
        internal int CaixaId { get; set; }

        internal virtual Caixa Caixa { get; set; }
        internal virtual Cargo Cargo { get; set; }
    }
}
