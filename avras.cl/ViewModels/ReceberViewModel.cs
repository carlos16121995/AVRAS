using System;
using System.Collections.Generic;
using System.Text;

namespace avras.cl.ViewModels
{
    public class ReceberViewModel
    {
        public int ContaId { get; set; }
        public DateTime DataRecebimento { get; set; }
        public decimal ValorRecebimento { get; set; }
        public byte Isento { get; set; }
        public int? AluguelId { get; set; }
        public int? VendaId { get; set; }
        public int? PatrocinioId { get; set; }
        public int? PessoaId { get; set; }

        public virtual AluguelViewModel Aluguel { get; set; }
        public virtual ContaViewModel Conta { get; set; }
        public virtual PatrocinadoresViewModel Patrocinio { get; set; }
        public virtual PessoaViewModel Pessoa { get; set; }
        public virtual VendaViewModel Venda { get; set; }
    }
}
