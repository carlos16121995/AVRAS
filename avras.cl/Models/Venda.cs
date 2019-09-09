using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class Venda
    {
        internal Venda()
        {
            ItensVenda = new HashSet<ItensVenda>();
            Receber = new HashSet<Receber>();
        }

        internal int Id { get; set; }
        internal int? PessoaId { get; set; }
        internal DateTime DataVenda { get; set; }
        internal int CargoId { get; set; }

        internal virtual Cargo Cargo { get; set; }
        internal virtual Pessoa Pessoa { get; set; }
        internal virtual ICollection<ItensVenda> ItensVenda { get; set; }
        internal virtual ICollection<Receber> Receber { get; set; }
    }
}
