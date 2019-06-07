using System;
using System.Collections.Generic;

namespace A.V.R.A.S.CL.Models
{
    internal partial class ItensVenda
    {
        public int ProdutoId { get; set; }
        public int VendaId { get; set; }
        public int Quantidade { get; set; }
        public decimal ProdutoValorUnitario { get; set; }

        public virtual Produto Produto { get; set; }
        public virtual Venda Venda { get; set; }
    }
}
