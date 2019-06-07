using System;
using System.Collections.Generic;

namespace A.V.R.A.S.Models
{
    public partial class Patrocinadores
    {
        public Patrocinadores()
        {
            Receber = new HashSet<Receber>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public int Parcelas { get; set; }

        public virtual ICollection<Receber> Receber { get; set; }
    }
}
