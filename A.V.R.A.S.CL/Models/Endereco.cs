using System;
using System.Collections.Generic;

namespace A.V.R.A.S.CL.Models
{
    internal partial class Endereco
    {
        public int PessoaId { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
