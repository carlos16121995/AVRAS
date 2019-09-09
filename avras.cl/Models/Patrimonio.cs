using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class Patrimonio
    {
        internal int Id { get; set; }
        internal string Nome { get; set; }
        internal string Descricao { get; set; }
        internal int Quantidade { get; set; }
        internal decimal? ValorCompra { get; set; }
        internal decimal? ValorPerda { get; set; }
        internal byte Disponibilidade { get; set; }
        internal string Anotacao { get; set; }
        internal DateTime? DataAquisicao { get; set; }
        internal DateTime? DataPerda { get; set; }
        internal int TipoPatrimonioId { get; set; }

        internal virtual TipoPatrimonio TipoPatrimonio { get; set; }
    }
}
