using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class TipoProduto
    {
        internal TipoProduto()
        {
            Produto = new HashSet<Produto>();
        }

        internal int Id { get; set; }
        internal string Nome { get; set; }
        internal string SrcImagem { get; set; }

        internal virtual ICollection<Produto> Produto { get; set; }
    }
}
