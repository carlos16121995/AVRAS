using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class TipoConta
    {
        internal TipoConta()
        {
            Conta = new HashSet<Conta>();
        }

        internal int Id { get; set; }
        internal string Nome { get; set; }
        internal string Descricao { get; set; }

        internal virtual ICollection<Conta> Conta { get; set; }
    }
}
