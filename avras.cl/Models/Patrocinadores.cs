using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class Patrocinadores
    {
        internal Patrocinadores()
        {
            Receber = new HashSet<Receber>();
        }

        internal int Id { get; set; }
        internal string Nome { get; set; }
        internal DateTime DataCadastro { get; set; }
        internal decimal Valor { get; set; }
        internal int Parcelas { get; set; }
        internal string SrcImagem { get; set; }
        internal string Descricao { get; set; }

        internal virtual ICollection<Receber> Receber { get; set; }
    }
}
