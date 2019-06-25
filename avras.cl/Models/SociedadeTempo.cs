using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class SociedadeTempo
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int PessoaId { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
