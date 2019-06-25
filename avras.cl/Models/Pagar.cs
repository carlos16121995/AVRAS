using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class Pagar
    {
        public int ContaId { get; set; }
        public decimal ValorPago { get; set; }
        public DateTime DataPagamento { get; set; }
        public int Parcelas { get; set; }

        public virtual Conta Conta { get; set; }
    }
}
