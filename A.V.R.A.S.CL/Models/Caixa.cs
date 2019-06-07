using System;
using System.Collections.Generic;

namespace A.V.R.A.S.CL.Models
{
    internal partial class Caixa
    {
        public Caixa()
        {
            ControleCaixa = new HashSet<ControleCaixa>();
            FluxoCaixa = new HashSet<FluxoCaixa>();
        }

        public int Id { get; set; }
        public decimal Valor { get; set; }

        public virtual ICollection<ControleCaixa> ControleCaixa { get; set; }
        public virtual ICollection<FluxoCaixa> FluxoCaixa { get; set; }
    }
}
