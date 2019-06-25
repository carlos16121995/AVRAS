using System;
using System.Collections.Generic;
using System.Text;
using avras.cl.ViewModels;

namespace avras.cl.ViewModels
{
    public class ControleCaixaViewModel
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

        public virtual CaixaViewModel Caixa { get; set; }
        public virtual ContaViewModel Conta { get; set; }
        public virtual PessoaViewModel Pessoa { get; set; }
        public virtual RetiradaCaixaViewModel RetiradaCaixa { get; set; }
    }
}
