using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class ControleCaixa
    {
        internal ControleCaixa()
        {
            Receber = new HashSet<Receber>();
        }

        internal int Id { get; set; }
        internal int CaixaId { get; set; }
        internal string Descricao { get; set; }
        internal DateTime DataAbertura { get; set; }
        internal DateTime? DataFechamento { get; set; }
        internal decimal ValorAbertura { get; set; }
        internal decimal? ValorFechamento { get; set; }
        internal int PessoaId { get; set; }

        internal virtual Caixa Caixa { get; set; }
        internal virtual Pessoa Pessoa { get; set; }
        internal virtual ICollection<Receber> Receber { get; set; }
    }
}
