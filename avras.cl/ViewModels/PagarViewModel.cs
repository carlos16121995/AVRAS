using System;
using System.Collections.Generic;
using System.Text;
using avras.cl.ViewModels;

namespace avras.cl.ViewModels
{
    public class PagarViewModel
    {
        public int ContaId { get; set; }
        public decimal ValorPago { get; set; }
        public DateTime DataPagamento { get; set; }
        public int Parcelas { get; set; }

        public virtual ContaViewModel Conta { get; set; }
    }
}
