using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class Cargo
    {
        public Cargo()
        {
            Pendencia = new HashSet<Pendencia>();
            RetiradaCaixa = new HashSet<RetiradaCaixa>();
            Venda = new HashSet<Venda>();
        }

        public int Id { get; set; }
        public int MandadoId { get; set; }
        public int PessoaId { get; set; }
        public int TipoCargoId { get; set; }

        public virtual Mandado Mandado { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual TipoCargo TipoCargo { get; set; }
        public virtual ICollection<Pendencia> Pendencia { get; set; }
        public virtual ICollection<RetiradaCaixa> RetiradaCaixa { get; set; }
        public virtual ICollection<Venda> Venda { get; set; }
    }
}
