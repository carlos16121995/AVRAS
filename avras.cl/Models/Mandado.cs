using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class Mandado
    {
        public Mandado()
        {
            Cargo = new HashSet<Cargo>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Resumo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public virtual ICollection<Cargo> Cargo { get; set; }
    }
}
