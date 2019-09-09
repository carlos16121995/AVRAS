using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class SociedadeTempo
    {
        internal int Id { get; set; }
        internal DateTime DataInicio { get; set; }
        internal DateTime? DataFim { get; set; }
        internal int PessoaId { get; set; }

        internal virtual Pessoa Pessoa { get; set; }
    }
}
