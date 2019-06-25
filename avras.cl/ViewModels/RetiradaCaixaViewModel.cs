using System;
using System.Collections.Generic;
using System.Text;

namespace avras.cl.ViewModels
{
    public class RetiradaCaixaViewModel
    {
        public int Id { get; set; }
        public string Motivo { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public int CargoId { get; set; }

        public virtual CargoViewModel Cargo { get; set; }
        public virtual ICollection<ControleCaixaViewModel> ControleCaixa { get; set; }
    }
}
