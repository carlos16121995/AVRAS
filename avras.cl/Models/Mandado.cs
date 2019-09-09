using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class Mandado
    {
        internal Mandado()
        {
            Cargo = new HashSet<Cargo>();
        }

        internal int Id { get; set; }
        internal string Nome { get; set; }
        internal string Resumo { get; set; }
        internal DateTime DataInicio { get; set; }
        internal DateTime DataFim { get; set; }

        internal virtual ICollection<Cargo> Cargo { get; set; }
    }
}
