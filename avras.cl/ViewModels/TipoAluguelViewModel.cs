
using System;
using System.Collections.Generic;
using System.Text;

namespace avras.cl.ViewModels
{
    public class TipoAluguelViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        public virtual ICollection<AluguelViewModel> Aluguel { get; set; }
    }
}
