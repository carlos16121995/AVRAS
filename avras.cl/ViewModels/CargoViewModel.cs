using System;
using System.Collections.Generic;
using System.Text;
using avras.cl.ViewModels;

namespace avras.cl.ViewModels
{
    public class CargoViewModel
    {
        public int Id { get; set; }
        public int MandadoId { get; set; }
        public int PessoaId { get; set; }
        public int TipoCargoId { get; set; }

        public virtual MandadoViewModel Mandado { get; set; }
        public virtual PessoaViewModel Pessoa { get; set; }
        public virtual TipoCargoViewModel TipoCargo { get; set; }
        public virtual ICollection<PendenciaViewModel> Pendencia { get; set; }
        public virtual ICollection<RetiradaCaixaViewModel> RetiradaCaixa { get; set; }
        public virtual ICollection<VendaViewModel> Venda { get; set; }
    }
}
