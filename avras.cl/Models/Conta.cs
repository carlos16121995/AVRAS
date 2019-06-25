using System;
using System.Collections.Generic;

namespace avras.cl.Models
{
    internal partial class Conta
    {
        public Conta()
        {
            ControleCaixa = new HashSet<ControleCaixa>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public int TipoId { get; set; }
        public int? ContaCorrenteId { get; set; }

        public virtual ContaCorrente ContaCorrente { get; set; }
        public virtual TipoConta Tipo { get; set; }
        public virtual Pagar Pagar { get; set; }
        public virtual Receber Receber { get; set; }
        public virtual ICollection<ControleCaixa> ControleCaixa { get; set; }
    }
}
