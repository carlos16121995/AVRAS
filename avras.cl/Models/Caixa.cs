using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class Caixa
    {
        public Caixa()
        {
            ControleCaixa = new HashSet<ControleCaixa>();
            MovimentacaoCaixa = new HashSet<MovimentacaoCaixa>();
        }

        public int Id { get; set; }
        public decimal Valor { get; set; }

        public virtual ICollection<ControleCaixa> ControleCaixa { get; set; }
        public virtual ICollection<MovimentacaoCaixa> MovimentacaoCaixa { get; set; }
    }
}
