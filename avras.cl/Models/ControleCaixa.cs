using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class ControleCaixa
    {
        public int Id { get; set; }
        public int CaixaId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }
        public decimal ValorAbertura { get; set; }
        public decimal? ValorFechamento { get; set; }
        public int PessoaId { get; set; }
        public int? ContaId { get; set; }
        public int? RetiradaCaixaId { get; set; }

        public virtual Caixa Caixa { get; set; }
        public virtual Conta Conta { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual RetiradaCaixa RetiradaCaixa { get; set; }
    }
}
