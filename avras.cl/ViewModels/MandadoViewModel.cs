using System;
using System.Collections.Generic;
using System.Text;
using avras.cl.ViewModels;

namespace avras.cl.ViewModels
{
    public class MandadoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Resumo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public virtual ICollection<CargoViewModel> Cargo { get; set; }
    }
}
