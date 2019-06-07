using System;
using System.Collections.Generic;

namespace A.V.R.A.S.CL.Models
{
    internal partial class FluxoCaixa
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public int? RetiradaCaixaId { get; set; }
        public int CaixaId { get; set; }
        public int? ContaId { get; set; }

        public virtual Caixa Caixa { get; set; }
        public virtual Conta Conta { get; set; }
        public virtual RetiradaCaixa RetiradaCaixa { get; set; }
    }
}
