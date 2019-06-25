using System;
using System.Collections.Generic;
using System.Text;
using avras.cl.ViewModels;

namespace avras.cl.ViewModels
{
    public class AluguelViewModel
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public int TipoAluguelId { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public DateTime DataReserva { get; set; }

        public virtual PessoaViewModel Pessoa { get; set; }
        public virtual TipoAluguelViewModel TipoAluguel { get; set; }
        public virtual ICollection<ReceberViewModel> Receber { get; set; }
    }
}
