using System;
using System.Collections.Generic;
using System.Text;

namespace avras.cl.ViewModels
{
    public class SociedadeTempoViewModel
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int PessoaId { get; set; }

        public virtual PessoaViewModel Pessoa { get; set; }
    }
}
