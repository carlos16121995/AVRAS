using System;
using System.Collections.Generic;

namespace A.V.R.A.S.CL.Models
{
    internal partial class Pendencia
    {
        public Pendencia()
        {
            Pessoa = new HashSet<Pessoa>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Pessoa> Pessoa { get; set; }
    }
}
