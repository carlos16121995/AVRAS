using avras.cl.ViewModels;
using System.Collections.Generic;
namespace avras.cl.ViewModels
{
    public class TipoAluguelViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        public virtual ICollection<AluguelViewModel> Aluguel { get; set; }
    }
}
