using System;
using System.Collections.Generic;

namespace A.V.R.A.S.CL.Models
{
    internal partial class ProdutoCategoria
    {
        public ProdutoCategoria()
        {
            Produto = new HashSet<Produto>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Produto> Produto { get; set; }
    }
}
