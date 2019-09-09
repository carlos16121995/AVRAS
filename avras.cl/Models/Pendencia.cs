using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class Pendencia
    {
        internal Pendencia()
        {
            Pessoa = new HashSet<Pessoa>();
        }

        internal int Id { get; set; }
        internal string Nome { get; set; }
        internal string Descricao { get; set; }
        internal DateTime DataSolicitacao { get; set; }
        internal DateTime? DataDeferimento { get; set; }
        internal int? CargoId { get; set; }

        internal virtual Cargo Cargo { get; set; }
        internal virtual ICollection<Pessoa> Pessoa { get; set; }
    }
}
