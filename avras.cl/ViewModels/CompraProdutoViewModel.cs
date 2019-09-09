using avras.cl.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace avras.cl.ViewModels
{
    public class CompraProdutoViewModel
    {
        internal int Id { get; set; }
        internal decimal ValorCompra { get; set; }
        internal string Quantidade { get; set; }
        internal DateTime DataCompra { get; set; }
        internal int ProdutoId { get; set; }

        internal virtual ProdutoViewModel Produto { get; set; }
    }
}
