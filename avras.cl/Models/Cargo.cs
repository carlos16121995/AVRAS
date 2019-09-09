using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class Cargo
    {
        internal Cargo()
        {
            MovimentacaoCaixa = new HashSet<MovimentacaoCaixa>();
            MovimentacaoConta = new HashSet<MovimentacaoConta>();
            Pendencia = new HashSet<Pendencia>();
            Venda = new HashSet<Venda>();
        }

        internal int Id { get; set; }
        internal int MandadoId { get; set; }
        internal int PessoaId { get; set; }
        internal int TipoCargoId { get; set; }

        internal virtual Mandado Mandado { get; set; }
        internal virtual Pessoa Pessoa { get; set; }
        internal virtual TipoCargo TipoCargo { get; set; }
        internal virtual ICollection<MovimentacaoCaixa> MovimentacaoCaixa { get; set; }
        internal virtual ICollection<MovimentacaoConta> MovimentacaoConta { get; set; }
        internal virtual ICollection<Pendencia> Pendencia { get; set; }
        internal virtual ICollection<Venda> Venda { get; set; }
    }
}
