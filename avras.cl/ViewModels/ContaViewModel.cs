using System;
using System.Collections.Generic;
using System.Text;
using avras.cl.ViewModels;

namespace avras.cl.ViewModels
{
    public class ContaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public int TipoId { get; set; }
        public int? ContaCorrenteId { get; set; }

        public virtual ContaCorrenteViewModel ContaCorrente { get; set; }
        public virtual TipoContaViewModel Tipo { get; set; }
        public virtual PagarViewModel Pagar { get; set; }
        public virtual ReceberViewModel Receber { get; set; }
        public virtual ICollection<ControleCaixaViewModel> ControleCaixa { get; set; }
    }
}
