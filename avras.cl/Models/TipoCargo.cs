using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class TipoCargo
    {
        public TipoCargo()
        {
            Cargo = new HashSet<Cargo>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Cargo> Cargo { get; set; }
    }
}
