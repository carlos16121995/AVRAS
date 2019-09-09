using System;
using System.Collections.Generic;
using System.Text;
using avras.cl.ViewModels;

namespace avras.cl.ViewModels
{
    public class PatrimonioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal? ValorCompra { get; set; }
        public decimal? ValorPerda { get; set; }
        public byte Disponibilidade { get; set; }
        public string Anotacao { get; set; }
        public DateTime? DataAquisicao { get; set; }
        public DateTime? DataPerda { get; set; }
        public int TipoPatrimonioId { get; set; }

        public virtual TipoPatrimonioViewModel TipoPatrimonio { get; set; }
    }
}
