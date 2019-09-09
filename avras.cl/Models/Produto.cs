using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class Produto
    {
        internal Produto()
        {
            CompraProduto = new HashSet<CompraProduto>();
            ItensVenda = new HashSet<ItensVenda>();
        }

        internal int Id { get; set; }
        internal string Nome { get; set; }
        internal decimal ValorVenda { get; set; }
        internal byte Disponível { get; set; }
        internal int Estoque { get; set; }
        internal int EstoqueMinimo { get; set; }
        internal int CategoriaId { get; set; }

        internal virtual TipoProduto Categoria { get; set; }
        internal virtual ICollection<CompraProduto> CompraProduto { get; set; }
        internal virtual ICollection<ItensVenda> ItensVenda { get; set; }
    }
}
