using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class Pendencia
    {
        public Pendencia()
        {
            Pessoa = new HashSet<Pessoa>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public DateTime? DataDeferimento { get; set; }
        public int CargoId { get; set; }

        public virtual Cargo Cargo { get; set; }
        public virtual ICollection<Pessoa> Pessoa { get; set; }
    }
}
