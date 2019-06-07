using System;
using System.Collections.Generic;

namespace A.V.R.A.S.CL.Models
{
    internal partial class Aluguel
    {
        public Aluguel()
        {
            Receber = new HashSet<Receber>();
        }

        public int Id { get; set; }
        public int PessoaId { get; set; }
        public int TipoAluguelId { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public DateTime DataReserva { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public virtual TipoAluguel TipoAluguel { get; set; }
        public virtual ICollection<Receber> Receber { get; set; }
    }
}
