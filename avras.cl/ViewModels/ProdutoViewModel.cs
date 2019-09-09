using System;
using System.Collections.Generic;
using System.Text;

namespace avras.cl.ViewModels
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorVenda { get; set; }
        public byte Disponível { get; set; }
        public int Estoque { get; set; }
        public int EstoqueMinimo { get; set; }
        public int CategoriaId { get; set; }

        public virtual TipoProdutoViewModel Categoria { get; set; }
        public virtual ICollection<CompraProdutoViewModel> CompraProduto { get; set; }
        public virtual ICollection<ItensVendaViewModel> ItensVenda { get; set; }
    }
}
