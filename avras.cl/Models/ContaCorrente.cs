using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class ContaCorrente
    {
        internal ContaCorrente()
        {
            Conta = new HashSet<Conta>();
            MovimentacaoConta = new HashSet<MovimentacaoConta>();
        }

        internal int Id { get; set; }
        internal decimal Valor { get; set; }

        internal virtual ICollection<Conta> Conta { get; set; }
        internal virtual ICollection<MovimentacaoConta> MovimentacaoConta { get; set; }
    }
}
