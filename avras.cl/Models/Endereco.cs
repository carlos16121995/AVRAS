using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class Endereco
    {
        internal int PessoaId { get; set; }
        internal string Cep { get; set; }
        internal string Cidade { get; set; }
        internal string Bairro { get; set; }
        internal string Rua { get; set; }
        internal int Numero { get; set; }
        internal string Complemento { get; set; }

        internal virtual Pessoa Pessoa { get; set; }
    }
}
