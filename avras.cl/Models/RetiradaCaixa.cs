using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class RetiradaCaixa
    {
        public RetiradaCaixa()
        {
            ControleCaixa = new HashSet<ControleCaixa>();
        }

        public int Id { get; set; }
        public string Motivo { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public int CargoId { get; set; }

        public virtual Cargo Cargo { get; set; }
        public virtual ICollection<ControleCaixa> ControleCaixa { get; set; }
    }
}
