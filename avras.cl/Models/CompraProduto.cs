using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class CompraProduto
    {
        internal int Id { get; set; }
        internal decimal ValorCompra { get; set; }
        internal string Quantidade { get; set; }
        internal DateTime DataCompra { get; set; }
        internal int ProdutoId { get; set; }

        internal virtual Produto Produto { get; set; }
    }
}
