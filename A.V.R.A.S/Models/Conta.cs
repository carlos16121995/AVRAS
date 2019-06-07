using System;
using System.Collections.Generic;

namespace A.V.R.A.S.Models
{
    public partial class Conta
    {
        public Conta()
        {
            FluxoCaixa = new HashSet<FluxoCaixa>();
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
        public virtual ICollection<FluxoCaixa> FluxoCaixa { get; set; }
    }
}
