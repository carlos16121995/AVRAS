using System;
using System.Collections.Generic;

namespace A.V.R.A.S.CL.Models
{
    internal partial class Venda
    {
        public Venda()
        {
            ItensVenda = new HashSet<ItensVenda>();
            Receber = new HashSet<Receber>();
        }

        public int Id { get; set; }
        public int? PessoaId { get; set; }
        public DateTime DataVenda { get; set; }
        public int SocioId { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public virtual ICollection<ItensVenda> ItensVenda { get; set; }
        public virtual ICollection<Receber> Receber { get; set; }
    }
}
