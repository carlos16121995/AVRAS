using System;
using System.Collections.Generic;
using System.Text;
using avras.cl.ViewModels;

namespace avras.cl.ViewModels
{
    public class PendenciaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public DateTime? DataDeferimento { get; set; }
        public int CargoId { get; set; }

        public virtual CargoViewModel Cargo { get; set; }
        public virtual ICollection<PessoaViewModel> Pessoa { get; set; }
    }
}
