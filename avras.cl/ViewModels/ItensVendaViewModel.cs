using System;
using System.Collections.Generic;
using System.Text;
using avras.cl.ViewModels;

namespace avras.cl.ViewModels
{
    public class ItensVendaViewModel
    {
        public int ProdutoId { get; set; }
        public int VendaId { get; set; }
        public int Quantidade { get; set; }
        public decimal ProdutoValorUnitario { get; set; }

        public virtual ProdutoViewModel Produto { get; set; }
        public virtual VendaViewModel Venda { get; set; }
    }
}
