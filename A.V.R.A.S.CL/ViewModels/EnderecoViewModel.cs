using System;
using System.Collections.Generic;
using System.Text;

namespace A.V.R.A.S.CL.ViewModels
{
    public class EnderecoViewModel
    {
        public int PessoaId { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }

        public virtual PessoaViewModel Pessoa { get; set; }
    }
}
