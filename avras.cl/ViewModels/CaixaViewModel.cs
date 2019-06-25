using System;
using System.Collections.Generic;
using System.Text;
using avras.cl.ViewModels;

namespace avras.cl.ViewModels
{
    public class CaixaViewModel
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }

        public virtual ICollection<ControleCaixaViewModel> ControleCaixa { get; set; }
    }
}
