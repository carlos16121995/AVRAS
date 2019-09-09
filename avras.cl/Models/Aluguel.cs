using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class Aluguel
    {
        internal Aluguel()
        {
            Receber = new HashSet<Receber>();
        }

        internal int Id { get; set; }
        internal int PessoaId { get; set; }
        internal int TipoAluguelId { get; set; }
        internal DateTime DataSolicitacao { get; set; }
        internal DateTime DataReserva { get; set; }

        internal virtual Pessoa Pessoa { get; set; }
        internal virtual TipoAluguel TipoAluguel { get; set; }
        internal virtual ICollection<Receber> Receber { get; set; }
    }
}
