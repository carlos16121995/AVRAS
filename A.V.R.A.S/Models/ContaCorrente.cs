using System;
using System.Collections.Generic;

namespace A.V.R.A.S.Models
{
    public partial class ContaCorrente
    {
        public ContaCorrente()
        {
            Conta = new HashSet<Conta>();
        }

        public int Id { get; set; }
        public decimal Valor { get; set; }

        public virtual ICollection<Conta> Conta { get; set; }
    }
}
