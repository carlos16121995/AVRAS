using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class ItensVenda
    {
        internal int ProdutoId { get; set; }
        internal int VendaId { get; set; }
        internal int Quantidade { get; set; }
        internal decimal ProdutoValorUnitario { get; set; }

        internal virtual Produto Produto { get; set; }
        internal virtual Venda Venda { get; set; }
    }
}
