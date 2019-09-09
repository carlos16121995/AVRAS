using System;
using System.Collections.Generic;
using System.Text;
using avras.cl.ViewModels;

namespace avras.cl.ViewModels
{
    public class TipoProdutoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SrcImagem { get; set; }

        public virtual ICollection<ProdutoViewModel> Produto { get; set; }
    }
}
