using System;
using System.Collections.Generic;
using System.Text;

namespace avras.cl.ViewModels
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CategoriaId { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal ValorVenda { get; set; }
        public byte Disponível { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeMinima { get; set; }

        public virtual ProdutoCategoria Categoria { get; set; }
        public virtual ICollection<ItensVendaViewModel> ItensVenda { get; set; }
    }
}
