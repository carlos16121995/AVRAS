using System;
using System.Collections.Generic;

namespace A.V.R.A.S.CL.Models
{
    internal partial class Produto
    {
        public Produto()
        {
            ItensVenda = new HashSet<ItensVenda>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int CategoriaId { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal ValorVenda { get; set; }
        public byte Disponível { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeMinima { get; set; }

        public virtual ProdutoCategoria Categoria { get; set; }
        public virtual ICollection<ItensVenda> ItensVenda { get; set; }
    }
}
