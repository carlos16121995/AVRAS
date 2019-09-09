using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class Receber
    {
        internal int ContaId { get; set; }
        internal DateTime? DataRecebimento { get; set; }
        internal decimal? ValorRecebimento { get; set; }
        internal byte Isento { get; set; }
        internal int? AluguelId { get; set; }
        internal int? VendaId { get; set; }
        internal int? PatrocinioId { get; set; }
        internal int? PessoaId { get; set; }
        internal int? ControleId { get; set; }

        internal virtual Aluguel Aluguel { get; set; }
        internal virtual Conta Conta { get; set; }
        internal virtual ControleCaixa Controle { get; set; }
        internal virtual Patrocinadores Patrocinio { get; set; }
        internal virtual Pessoa Pessoa { get; set; }
        internal virtual Venda Venda { get; set; }
    }
}
