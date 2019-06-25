using System;
using System.Collections.Generic;
using System.Text;

namespace avras.cl.ViewModels
{
    public class VendaViewModel
    {
        public int Id { get; set; }
        public int? PessoaId { get; set; }
        public DateTime DataVenda { get; set; }
        public int CargoId { get; set; }

        public virtual CargoViewModel Cargo { get; set; }
        public virtual PessoaViewModel Pessoa { get; set; }
        public virtual ICollection<ItensVendaViewModel> ItensVenda { get; set; }
        public virtual ICollection<ReceberViewModel> Receber { get; set; }
    }
}
