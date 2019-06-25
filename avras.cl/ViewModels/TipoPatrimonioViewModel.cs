using System;
using System.Collections.Generic;
using System.Text;

namespace avras.cl.ViewModels
{
    public class TipoPatrimonioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<PatrimonioViewModel> Patrimonio { get; set; }
    }
}
