using System;
using System.Collections.Generic;

namespace A.V.R.A.S.Models
{
    public partial class Cargo
    {
        public int Id { get; set; }
        public int MandadoId { get; set; }
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual Mandado Mandado { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}
