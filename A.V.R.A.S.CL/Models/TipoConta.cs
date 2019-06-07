using System;
using System.Collections.Generic;

namespace A.V.R.A.S.CL.Models
{
    internal partial class TipoConta
    {
        public TipoConta()
        {
            Conta = new HashSet<Conta>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Conta> Conta { get; set; }
    }
}
