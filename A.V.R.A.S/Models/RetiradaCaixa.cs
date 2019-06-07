using System;
using System.Collections.Generic;

namespace A.V.R.A.S.Models
{
    public partial class RetiradaCaixa
    {
        public RetiradaCaixa()
        {
            FluxoCaixa = new HashSet<FluxoCaixa>();
        }

        public int Id { get; set; }
        public string Motivo { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public int PessoaId { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public virtual ICollection<FluxoCaixa> FluxoCaixa { get; set; }
    }
}
