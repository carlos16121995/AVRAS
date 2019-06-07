using System;
using System.Collections.Generic;

namespace A.V.R.A.S.CL.Models
{
    internal partial class Patrimonio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descicao { get; set; }
        public int Quantidade { get; set; }
        public decimal? ValorCompra { get; set; }
        public decimal? ValorPerda { get; set; }
        public byte Disponibilidade { get; set; }
        public string Anotacao { get; set; }
        public DateTime? DataAquisicao { get; set; }
        public DateTime? DataPerda { get; set; }
        public int TipoPatrimonioId { get; set; }

        public virtual TipoPatrimonio TipoPatrimonio { get; set; }
    }
}
