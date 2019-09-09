using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class Conta
    {
        internal int Id { get; set; }
        internal string Nome { get; set; }
        internal string Descricao { get; set; }
        internal decimal Valor { get; set; }
        internal DateTime Data { get; set; }
        internal int TipoId { get; set; }
        internal int? ContaCorrenteId { get; set; }

        internal virtual ContaCorrente ContaCorrente { get; set; }
        internal virtual TipoConta Tipo { get; set; }
        internal virtual Pagar Pagar { get; set; }
        internal virtual Receber Receber { get; set; }
    }
}
