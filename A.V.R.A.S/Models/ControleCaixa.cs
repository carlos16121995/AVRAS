using System;
using System.Collections.Generic;

namespace A.V.R.A.S.Models
{
    public partial class ControleCaixa
    {
        public int Id { get; set; }
        public int CaixaId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }
        public decimal ValorAbertura { get; set; }
        public decimal? ValorFechamento { get; set; }
        public int PessoaId { get; set; }

        public virtual Caixa Caixa { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}
